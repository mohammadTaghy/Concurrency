using System.Text;

namespace Parallel_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int x = int.Parse('-1');
            //Console.WriteLine(x);
            HighAndLow("8 3 -5 42 -1 0 0 -9 4 7 4 -4");

            Console.WriteLine("Hello, World!");
            // MultiplyBy2(GenarateValues());

        }
        public static string HighAndLow(string numbers)
        {
            int? lowest = null, highest = null;
            string[] splitArray = numbers.Split(' ');
            foreach (string ch in splitArray)
            {
                int item =int.Parse(ch);
                if (lowest is null)
                    lowest = highest = item;
                else if (lowest > item)
                    lowest = item;
                else if (highest < item)
                    highest = item;
            }
            return $"{highest} {lowest}";
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
        public static int[] Likes(string word)
        {
            HashSet<int> upperIndexes = new();
            for (int i = 0; i < word.Length; i++)
                if (char.IsUpper(word[i]))
                    upperIndexes.Add(i);

            return upperIndexes.ToArray();
        }

    }
}
