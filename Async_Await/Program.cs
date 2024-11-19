

namespace Async_Await
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Method1();
        }

        private static async Task Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("method1 ThreadId=" + Thread.CurrentThread.ManagedThreadId);

                await Method2(i);
                Console.WriteLine("method1 ThreadId2=" + Thread.CurrentThread.ManagedThreadId);
            }

        }

        private static async Task Method2(int i)
        {
            Console.WriteLine("method2 ThreadId=" + Thread.CurrentThread.ManagedThreadId);

            await Task.Delay(500);
            Console.WriteLine("method2 ThreadId2="+ Thread.CurrentThread.ManagedThreadId);
        }
    }
}
