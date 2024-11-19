using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_Aggregate
{
    public class Aggregate_Benchmark
    {
        [Benchmark]
        public void ParallelSum()
        {
            IEnumerable<int> values = Genaratevalues();
            object mutex = new object();
            int result = 0;
            Parallel.ForEach(source: values,
            localInit: () => 0,
            body: (item, state, localValue) =>
            {
                Task.Delay(1000).Wait();
                return localValue + item;
            },
            localFinally: localValue =>
            {
                lock (mutex)
                    result += localValue;
            });
        }
        [Benchmark]
        public void ParallelLinqSum()
        {
            IEnumerable<int> values = Genaratevalues();
            _ = values.AsParallel().Sum();
        }
        [Benchmark]
        public void ParallelForSum()
        {
            int sum = 0;
            for (int i = 0; i < 100; i++)
            {
                sum += i;
            }
        }
        public IEnumerable<int> Genaratevalues()
        {
            for (int i = 0; i < 100; i++)
            {
                Task.Delay(1000).Wait();
                yield return i;
            }
        }
    }
}
