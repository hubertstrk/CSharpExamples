using System;
using System.Threading.Tasks;

namespace Task_WhenAll
{
    class Program
    {
        static void Main( string[] args )
        {
            Work work = new Work();
            // func with parameters and return type
            Func<int, long> a1 = new Func<int, long>( work.FindPrimeNumber );
            Func<int, long> a2 = new Func<int, long>( work.FindPrimeNumber );
            Func<int, long> a3 = new Func<int, long>( work.FindPrimeNumber );

            // a task can only have a return type (TResult)
            // but can execute a func
            Task<long> t1 = new Task<long>( () => { return a1.Invoke( 40000 ); } );
            Task<long> t2 = new Task<long>( () => { return a2.Invoke( 20000 ); } );
            Task<long> t3 = new Task<long>( () => { return a3.Invoke( 500000 ); } );
            t1.Start();
            t2.Start();
            t3.Start();
            Task[] tasks = new Task[] { t1, t2, t3 };
            Task result = Task.WhenAny( tasks );
            result.ContinueWith( t =>
             {
                 Console.WriteLine( t1.Result.ToString() );
                 Console.WriteLine( t2.Result.ToString() );
                 Console.WriteLine( t3.Result.ToString() );
                 Console.WriteLine( "Finished" );
             } );

            Console.WriteLine( "Waiting..." );
            Console.ReadKey();
        }
    }

    public class Work
    {
        public long FindPrimeNumber( int number )
        {
            int count = 0;
            long a = 2;
            while ( count < number )
            {
                //if ( count == 400000 )
                //    throw new ArgumentException();

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

            return ( --a );
        }
    }
}
