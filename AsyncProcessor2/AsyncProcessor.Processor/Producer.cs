using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProcessor.Processor
{
    public class Producer
    {
		public Task ProducerTask;

		public CancellationTokenSource Cts = new CancellationTokenSource();

		public event EventHandler<string> InfoMessage;

		private void OnInfoMessage(string message)
		{
			EventHandler<string> handler = InfoMessage;

			if (handler != null)
				handler.Invoke( this, message );
		}

		public void Start(Action action)
		{
			Cts = new CancellationTokenSource();

			ProducerTask = Task.Factory.StartNew( () =>
			{
				OnInfoMessage( "Producer: Started" );

				while (true)
				{
					action.Invoke();

					if (Cts.IsCancellationRequested)
					{
						OnInfoMessage( "Producer: Cancelled" );
						break;
					}
				}
			}, Cts.Token );
		}

		public void Stop()
		{
			Cts.Cancel();
		}

		public void Dispose()
		{
			if (ProducerTask != null)
				ProducerTask.Dispose();
			if (Cts != null)
				Cts.Dispose();
		}
	}
}
