namespace Parallel_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MultiplyBy2(GenarateValues());

        }
        static IEnumerable<int> GenarateValues()
        {
            for (int i = 0; i < 10; i++)
                yield return i;
        }
        static IEnumerable<int> MultiplyBy2(IEnumerable<int> values)
        {
            return values.AsParallel().Select(value => value * 2);
        }
        static IEnumerable<int> MultiplyBy2AsOrder(IEnumerable<int> values)
        {
            return values.AsParallel().AsOrdered().Select(value => value * 2);
        }
        static int ParallelSum(IEnumerable<int> values)
        {
            return values.AsParallel().Sum();
        }
    }
}
