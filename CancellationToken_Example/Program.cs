namespace CancellationToken_Example
{

    public class Program
    {
        public static async IAsyncEnumerable<int> GenerateNumbersWithCancellationAsync(CancellationToken cancellationToken)
        {
            for (int i = 1; i <= 10; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(500, cancellationToken); // Simulate asynchronous work
                yield return i;
            }
        }

        public static async Task Main(string[] args)
        {
            using var cts = new CancellationTokenSource();
            var token = cts.Token;

            var task = Task.Run(async () =>
            {
                await foreach (var number in GenerateNumbersWithCancellationAsync(token))
                {
                    Console.WriteLine(number);
                }
            });

            // Cancel the operation after 3 seconds
            await Task.Delay(3000);
            cts.Cancel();

            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation was canceled.");
            }
        }
    }
}
