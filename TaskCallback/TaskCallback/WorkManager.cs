using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCallback
{
    public class WorkManager
    {
        public void StartTask_Callback( Action action, Action onResult, Action onError )
        {
            Task<TaskResult> task = new Task<TaskResult>( () => 
            {
                try
                {
                    action.Invoke();
                    return new TaskResult { Message = "Everyting is fine", Success = true };
                }
                finally
                {
                    Console.WriteLine( "Action finally" );
                }
            } );

            task.ContinueWith( t => 
            {
                if ( t.IsFaulted )
                {
                    onError.Invoke();
                    return;
                }

                Console.WriteLine( task.Result.Message );
                onResult.Invoke();                
            } );
            task.Start();
        }
    }

    public static class WorkManagerStatic
    {
        public static void StartTask_Callback( this Func<Data, long> action, Data data, Action onResult, Action onError )
        {
            Task<long> task = new Task<long>( () =>
            {
                try
                {
                    long result = action.Invoke( data );
                    return result;
                }
                finally
                {
                    Console.WriteLine( "Action finally" );
                }
            } );

            task.ContinueWith( t =>
            {
                if ( t.IsFaulted )
                {
                    onError.Invoke();
                    return;
                }

                Console.WriteLine( task.Result.ToString() );
                onResult.Invoke();
            } );
            task.Start();
        }

        public static void StartTask_Logging( this Func<Data, long> action, Data data, Action onError )
        {
            Task<long> task = new Task<long>( () =>
            {
                try
                {
                    long result = action.Invoke( data );
                    return result;
                }
                finally
                {
                    Console.WriteLine( "Action finally" );
                }
            } );

            task.ContinueWith( t =>
            {
                if ( t.IsFaulted )
                {
                    onError.Invoke();
                    return;
                }

                Console.WriteLine( task.Result.ToString() );
            } );
            task.Start();
        }
    }

    public class TaskResult
    {
        public string Message { get; set; }
        public bool Success { get; set; } = false;
    }
}
