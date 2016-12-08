using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProcessor.Processor
{
	public class Consumer
	{
		public Task ConsumerTask;
		public Task WatcherTask;

		public BlockingCollection<string> Queue = new BlockingCollection<string>();

		public CancellationTokenSource Cts = new CancellationTokenSource();

		#region Events

		public event EventHandler<string> InfoMessage;
		public event EventHandler<DateTime> LastProcessed;
		public event EventHandler<int> QueueCount;

		private void OnInfoMessage(string message)
		{
			EventHandler<string> handler = InfoMessage;

			if (handler != null)
				handler.Invoke( this, message );
		}

		private void OnLastProcessed(DateTime lastPorcessed)
		{
			EventHandler<DateTime> handler = LastProcessed;

			if (handler != null)
				handler.Invoke( this, lastPorcessed );
		}

		private void OnQueueCount(int count)
		{
			EventHandler<int> handler = QueueCount;

			if (handler != null)
				handler.Invoke( this, count );
		}

		#endregion

		public void Start(Action<string> action)
		{
			Cts = new CancellationTokenSource();

			ConsumerTask = Task.Factory.StartNew( () =>
			{
				try
				{
					foreach (var item in Queue.GetConsumingEnumerable( Cts.Token ))
					{
						FileInfo fi = new FileInfo( item );

						action.Invoke( item );

						OnInfoMessage( "Finished" );

						OnLastProcessed( fi.CreationTimeUtc );

						if (Cts.IsCancellationRequested)
						{
							OnInfoMessage( "Stopped" );
							return;
						}
					}
				}
				catch (OperationCanceledException)
				{
					OnInfoMessage( "Stopped" );
					return;
				}
			}, Cts.Token );

			WatcherTask = Task.Factory.StartNew( () =>
			{
				try
				{
					while (true)
					{
						OnQueueCount( Queue.Count );

						Thread.Sleep( 500 );

						if (Cts.IsCancellationRequested)
						{
							return;
						}
					}
				}
				catch (OperationCanceledException)
				{
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
			if (WatcherTask != null)
				WatcherTask.Dispose();
			if (Queue != null)
				Queue.Dispose();
		}
	}
}
