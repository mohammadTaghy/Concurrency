using BenchmarkDotNet.Running;

namespace Parallel_Aggregate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Aggregate_Benchmark>();
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine(ParallelSum(Genaratevalues()));
            //Console.WriteLine(ParallelLinqSum(Genaratevalues()));
        }
        static int ParallelSum(IEnumerable<int> values)
        {
            object mutex = new object();
            int result = 0;
            Parallel.ForEach(source: values,
            localInit: () => 0,
            body: (item, state, localValue) => localValue + item,
            localFinally: localValue =>
            {
                lock (mutex)
                    result += localValue;
            });
            return result;
        }
       static  int ParallelLinqSum(IEnumerable<int> values)
        {
            return values.AsParallel().Sum();
        }
        static IEnumerable<int> Genaratevalues()
        {
            for (int i = 0; i < 100; i++)
            {
                yield return i;
            }
        }
    }
}
