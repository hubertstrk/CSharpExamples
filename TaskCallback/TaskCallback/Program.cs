using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCallback
{
    class Program
    {
        static void Main( string[] args )
        {
            /*
            Work work = new Work();
            WorkManager manager = new WorkManager();
            Action action = new Action( work.FindPrimeNumber );
            Action callback = new Action( () => { Console.WriteLine( "Callback" ); } );
            Action error = new Action( () => { Console.WriteLine( "Error" ); } );
            manager.StartTask_Callback( action, callback, error );
            Console.WriteLine( "Task started" );
            */

            /*
            Work work = new Work();
            Func<Data, long> action = new Func<Data, long>( work.FindPrimeNumber );
            Action callback = new Action( () => { Console.WriteLine( "Callback" ); } );
            Action error = new Action( () => { Console.WriteLine( "Error" ); } );

            Data data = new Data { Number = 500000 };
            action.StartTask_Callback( data, callback, error );
            Console.WriteLine( "Task started" );
            */

            Work work = new Work();
            Func<Data, long> action = new Func<Data, long>( work.FindPrimeNumber );
            Action error = new Action( () => { Console.WriteLine( "Error" ); } );

            Data data = new Data { Number = 500000 };
            action.StartTask_Logging( data, error );
            Console.WriteLine( "Task started" );

            Console.WriteLine( "Waiting..." );
            Console.ReadKey();
        }
    }

    public class Data
    {
        public int Number { get; set; }
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

        public long FindPrimeNumber( Data data )
        {
            int count = 0;
            long a = 2;
            while ( count < data.Number )
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
