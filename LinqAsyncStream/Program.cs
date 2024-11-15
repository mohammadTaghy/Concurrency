namespace LinqAsyncStream
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IAsyncEnumerable<int> values = SlowRange().WhereAwait(
                 async value =>
                 {
                     // Do some asynchronous work to determine
                     // if this element should be included.
                     await Task.Delay(10);
                     return value % 2 == 0;
                 });
            await foreach (int result in values)
            {
                Console.WriteLine(result);
            }
        }
        static async IAsyncEnumerable<int> SlowRange()
        {
            for (int i = 0; i != 10; ++i)
            {
                await Task.Delay(i * 100);
                yield return i;
            }
        }

    }
}
