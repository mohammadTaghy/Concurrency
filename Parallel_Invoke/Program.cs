using System.Diagnostics;

namespace Parallel_Invoke
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ParallelInvok();
            WitoutParallel();
            WithParallel();
        }
        static void ParallelInvok()
        {
            Action action1 = () =>
            {
                Console.WriteLine("Task 1 starting...");
                // Simulate some work with a delay
                Task.Delay(1000).Wait();
                Console.WriteLine("Task 1 completed.");
            };

            Action action2 = () =>
            {
                Console.WriteLine("Task 2 starting...");
                Task.Delay(2000).Wait();
                Console.WriteLine("Task 2 completed.");
            };

            Action action3 = () =>
            {
                Console.WriteLine("Task 3 starting...");
                Task.Delay(1500).Wait();
                Console.WriteLine("Task 3 completed.");
            };

            // Execute the tasks in parallel
            Parallel.Invoke(action1, action2, action3);

            Console.WriteLine("All tasks completed.");
        }
        static void WitoutParallel()
        {
            Stopwatch stopwatch = new Stopwatch();

            // Sequential execution
            stopwatch.Start();
            Method1();
            Method2();
            Method3();
            stopwatch.Stop();
            Console.WriteLine($"Sequential Execution Took {stopwatch.ElapsedMilliseconds} ms");
        }
        static void WithParallel()
        {
            // Parallel execution
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.Invoke(Method1, Method2, Method3);
            stopwatch.Stop();
            Console.WriteLine($"Parallel Execution Took {stopwatch.ElapsedMilliseconds} ms");
        }
        static void Method1()
        {
            Thread.Sleep(200);
            Console.WriteLine($"Method 1 completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        }

        static void Method2()
        {
            Thread.Sleep(200);
            Console.WriteLine($"Method 2 completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        }

        static void Method3()
        {
            Thread.Sleep(200);
            Console.WriteLine($"Method 3 completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
