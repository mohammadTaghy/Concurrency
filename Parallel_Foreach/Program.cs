namespace Parallel_Foreach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of numbers to process
            List<int> numbers = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                numbers.Add(i);
            }

            // Process the numbers in parallel
            Parallel.ForEach(numbers, number =>
            {
                // Simulate some work
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                int result = number * number;
                Console.WriteLine($"Number: {number}, Square: {result}, Thread: {Task.CurrentId}, ThreadId {Thread.CurrentThread.ManagedThreadId}");
            });

            Console.WriteLine("Processing complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}