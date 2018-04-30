using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTokenTimeout
{
	public class Program
	{
		public static void Main( string[] args )
		{
			CancellationTokenSource cts = new CancellationTokenSource();

			MyAsyncClass myClass = new MyAsyncClass();
			myClass.StartCalculationAsync( cts );
			Console.WriteLine( "press key to stop..." );
			Console.ReadKey();
		}
	}

	public class MyAsyncClass
	{
		public async void StartCalculationAsync( CancellationTokenSource cts )
		{
			await FindPrimeNumber( cts, 1000000 );
		}

		private void CancelAsync()
		{
			Console.WriteLine( "Cancel async called" );
		}

		private Task FindPrimeNumber( CancellationTokenSource cts, int n )
		{
			CancellationToken ct = cts.Token;
			ct.Register( () => CancelAsync() );

			Task t = new Task( () =>
			{
				int count = 0;
				long a = 2;
				while ( count < n )
				{
					if ( cts.Token.IsCancellationRequested )
					{
						//Console.WriteLine( "task cancelled" );
						//break;
					}

					long b = 2;
					int prime = 1;
					while ( b * b <= a )
					{
						if ( a % b == 0 )
						{
							prime = 0;
							break;
						}
						b++;
					}
					if ( prime > 0 )
						count++;
					a++;
				}
				//return ( --a );
			}, ct );
			t.Start();

			if ( !t.Wait( 2000 ) )
			{
				cts.Cancel( true );
			}

			return t;
		}
	}
}
