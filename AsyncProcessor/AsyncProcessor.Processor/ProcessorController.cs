using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProcessor.Processor
{
	public class ProcessorController : IDisposable
	{
		public Producer m_DownloadProducer;
		public Consumer m_DownloadConsumer;

		private string DownloadSourceFolder = @"C:\Temp\DownloadSource";

		#region Event Handler

		public EventHandler<string> Message;
		
		private void OnMessage(string message)
		{
			EventHandler<string> handler = Message;
			if (handler != null)
				handler.Invoke( this, message );
		}

		#endregion

		private DateTime _LastProcessedUTC = DateTime.MinValue;

		private void Initialize()
		{
			m_DownloadConsumer = new Consumer();
			m_DownloadConsumer.InfoMessage += DownloadConsumer_InfoMessage;

			m_DownloadProducer = new Producer();
			m_DownloadProducer.InfoMessage += DownloadProducer_InfoMessage;
		}

		public void Start()
		{
			if (m_DownloadConsumer != null && m_DownloadProducer != null)
			{
				OnMessage( "Producer/Consumer not stopped yet" );
				return;
			}

			Initialize();

			#region Consumer

			// start consumer
			// consumer does nothing as long as nothing is in the consumer queue
			m_DownloadConsumer.Start( delegate (ItemDownload item) 
			{
				// e.g. download image from server
				byte[] image = ReadImage( item.FileInfo.FullName );
				Thread.Sleep( 5000 );
			} );

			#endregion

			#region Producer

            // start producer
			m_DownloadProducer.Start( delegate()
			{
                // search for new files to download and add them to consumer queue in case new files are available
				List<FileInfo> newestFiles = SearchNewestFile();
				if (newestFiles != null && newestFiles.Count() > 0)
				{
					foreach (FileInfo fi in newestFiles)
					{
						ItemDownload download = new ItemDownload() { FileInfo = fi };

						// only add to queue in case queue is still open
						if (!m_DownloadConsumer.Queue.IsAddingCompleted)
						{
                            // add download job to queue => consumer starts to download stuff according to the download job properties
							m_DownloadConsumer.Queue.Add( download );
							_LastProcessedUTC = fi.CreationTimeUtc;
							OnMessage( string.Format( "Producer: Added {0} to queue", fi.Name ) );
						}
					}
				}

				Thread.Sleep( 1000 );
			} );

			#endregion
		}
		
		public void Stop()
		{
			if (m_DownloadConsumer == null && m_DownloadProducer == null)
			{
				OnMessage( "Producer/Consumer not started yet" );
				return;
			}

			if (m_DownloadConsumer.Running)
			{
				OnMessage( "Consumer is currently running. Wait until finished" );
				return;
			}

			m_DownloadConsumer.Stop();
			m_DownloadProducer.Stop();

			Task.WaitAll( new List<Task>() { m_DownloadConsumer.ConsumerTask, m_DownloadProducer.ProducerTask }.ToArray() );
			
			Destroy();
		}

		private void Destroy()
		{
			if (m_DownloadConsumer != null)
			{
				m_DownloadConsumer.InfoMessage -= DownloadConsumer_InfoMessage;
				m_DownloadConsumer.Dispose();
				m_DownloadConsumer = null;
			}

			if (m_DownloadProducer != null)
			{
				m_DownloadProducer.InfoMessage -= DownloadProducer_InfoMessage;
				m_DownloadProducer.Dispose();
				m_DownloadProducer = null;
			}
		}

		public byte[] ReadImage(string _FileName)
		{
			Thread.Sleep( 500 );

			byte[] buffer = null;

			using (FileStream fs = new FileStream( _FileName, FileMode.Open, FileAccess.Read ))
			{
				using (BinaryReader br = new BinaryReader( fs ))
				{
					long _TotalBytes = new FileInfo( _FileName ).Length;
					buffer = br.ReadBytes( (Int32)_TotalBytes );
				}
			}

			return buffer;
		}

		private List<FileInfo> SearchNewestFile()
		{
			DirectoryInfo dir = new DirectoryInfo( DownloadSourceFolder );

			IEnumerable<FileInfo> fileList = dir.GetFiles( "*.*", SearchOption.AllDirectories );

			IEnumerable<FileInfo> fileQuery =
				from file in fileList
				where file.Extension == ".ARW"
				orderby file.Name
				select file;

			var newestFile =
				(from file in fileQuery
				 orderby file.CreationTime
				 select file).Where( f => f.CreationTimeUtc > _LastProcessedUTC ).ToList();

			return newestFile;
		}

		public void Dispose()
		{
			Stop();
			Destroy();
		}

		private void DownloadConsumer_InfoMessage(object sender, string e)
		{
			OnMessage( e );
		}

		private void DownloadProducer_InfoMessage(object sender, string e)
		{
			OnMessage( e );
		}
	}
}