using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleWait
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new ActionController();

            XConsole.BusyIndicator<long>("Computing this", () => controller.LongRunningTask(10000000));
            XConsole.BusyIndicator<long>("Computing that", () => controller.LongRunningTask(1000));
            XConsole.BusyIndicator<long>("Computing something else", () => controller.LongRunningTask(1000000));
            XConsole.BusyIndicator<long>("Reading this", () => controller.LongRunningTask(10000));
            XConsole.BusyIndicator<long>("Reading that", () => controller.LongRunningTask(100000));

            Console.ReadKey();
        }
    }

    public class Spinner : IDisposable
    {
        private CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

        private Task SpinnerTask { get; set; }
        
        public void Start()
        {
            SpinnerTask = new Task(Draw, CancellationTokenSource.Token);
            SpinnerTask.Start();
        }

        public void Stop()
        {
            CancellationTokenSource.Cancel();
        }

        private void Draw()
        {
            while (true)
            {
                Console.Write(".");
                
                if (CancellationTokenSource.IsCancellationRequested)
                {
                    break;
                }

                Thread.Sleep(1000);
            }
        }

        public void Dispose()
        {
            if (SpinnerTask != null)
            {
                SpinnerTask.Wait();
                SpinnerTask.Dispose();
            }
        }
    }

    public static class XConsole
    {
        public static T BusyIndicator<T>(Func<T> action)
        {
            T result;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            using (var spinner = new Spinner())
            {
                spinner.Start();

                result = action();

                spinner.Stop();
            }

            Console.Write($" ({sw.ElapsedMilliseconds}ms)");
            Console.WriteLine();

            sw.Reset();

            return result;
        }

        public static T BusyIndicator<T>(string content, Func<T> func)
        {
            Console.Write(content);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            T result;

            using (var spinner = new Spinner())
            {
                spinner.Start();

                result = func.Invoke();

                spinner.Stop();
            }

            Console.Write($" ({sw.ElapsedMilliseconds}ms)");
            Console.WriteLine();

            sw.Reset();

            return result;
        }
    }

    public class ActionController
    {
        public long LongRunningTask(int n)
        {
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1;
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }
    }
}
