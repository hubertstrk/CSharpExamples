using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksRun
{
    class Program
    {
        static void Main( string[] args )
        {
            Work work = new Work();

            Task<long?> task = new Task<long?>( () =>
            {
                long? result = null;
                try
                {
                    result = work.FindPrimeNumber( 500000 );
                }
                catch ( Exception ex )
                {
                    Console.WriteLine( ex.Message );
                }
                return result;
            } );
            task.ContinueWith( t =>
            {
                Console.WriteLine( t.Exception.Message );
            }, TaskContinuationOptions.OnlyOnFaulted );
            task.ContinueWith( t =>
            {
                if ( t.Result.HasValue )
                    Console.WriteLine( t.Result.ToString() );
                else
                    Console.WriteLine( "Cannot write result." );
            }, TaskContinuationOptions.OnlyOnRanToCompletion );

            task.Start();
            Console.WriteLine( "Task started" );

            Console.WriteLine( "Waiting..." );
            Console.ReadKey();
        }
    }

    public class Work
    {
        public void FindPrimeNumber()
        {
            int count = 0;
            long a = 2;
            while ( count < 500000 )
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
        }

        public long FindPrimeNumber( int number )
        {
            int count = 0;
            long a = 2;
            while ( count < number )
            {
                if ( count == 400000 )
                    throw new ArgumentException();

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
