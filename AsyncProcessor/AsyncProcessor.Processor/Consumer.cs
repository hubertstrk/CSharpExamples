using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProcessor.Processor
{
	public class Consumer : IDisposable
	{
		public Task ConsumerTask;

		public BlockingCollection<ItemDownload> Queue = new BlockingCollection<ItemDownload>();
		
		public CancellationTokenSource Cts = new CancellationTokenSource();
		
		#region Events

		public event EventHandler<string> InfoMessage;

		private void OnInfoMessage( string message )
		{
			EventHandler<string> handler = InfoMessage;

			if (handler != null)
				handler.Invoke( this, message );
		}

		#endregion

		public bool Running = false;

		public void Start( Action<ItemDownload> action )
		{
			Cts = new CancellationTokenSource();

			ConsumerTask = Task.Factory.StartNew( () =>
			{
				try
				{
					foreach (var item in Queue.GetConsumingEnumerable( Cts.Token ))
					{
						Running = true;

						OnInfoMessage( "Consumer: Before processing" );

                        // download stuff using the job properties added to the queue
						action.Invoke( item );

						OnInfoMessage( "Consumer: After processing" );

						//if (!ProcessorQueue.IsAddingCompleted)
						//{
						//	ItemProcessor process = new ItemProcessor() { Data = image, FileInfo = item.FileInfo };
						//	ProcessorQueue.Add( process );
						//}

						if (Cts.IsCancellationRequested)
						{
							OnInfoMessage( "Consumer: Cancelled" );
							return;
						}

						Running = false;
					}
				}
				catch (OperationCanceledException)
				{
					OnInfoMessage( "Consumer: Cancelled" );
					return;
				}
			}, Cts.Token );
		}

		public void Stop()
		{
			Cts.Cancel();
			Queue.CompleteAdding();
		}

		public void Dispose()
		{
			if (Cts != null)
				Cts.Dispose();
			if (ConsumerTask != null)
				ConsumerTask.Dispose();
			if (Queue != null)
				Queue.Dispose();
		}
	}
}
