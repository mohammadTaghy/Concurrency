using BenchmarkDotNet.Running;

namespace Parallel_For
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //BenchmarkRunner.Run<BenchmarkExample>();
            UseParallelForeach();
            UseParallelFor();
            UseFor();
        }
        static void UseParallelForeach()
        {
            long totalSize = 0;
            string directoryPath = @"F:\D\music\Adele\Adele - 30";


            string[] files = Directory.GetFiles(directoryPath);
            Parallel.ForEach(files, file =>
            {
                FileInfo fi = new FileInfo(file);
                long size = fi.Length;
                Interlocked.Add(ref totalSize, size);
            });

            Console.WriteLine($"ParallelForeach Directory '{directoryPath}':");
            Console.WriteLine($"{files.Length:N0} files, {totalSize:N0} bytes");
        }
        static void UseParallelFor()
        {
            long totalSize = 0;
            string directoryPath = @"F:\D\music\Adele\Adele - 30";


            string[] files = Directory.GetFiles(directoryPath);
            Parallel.For(0, files.Length, index =>
            {
                FileInfo fi = new FileInfo(files[index]);
                long size = fi.Length;
                Interlocked.Add(ref totalSize, size);
            });

            Console.WriteLine($"ParallelFor Directory '{directoryPath}':");
            Console.WriteLine($"{files.Length:N0} files, {totalSize:N0} bytes");
        }
        static void UseFor()
        {
            long totalSize = 0;
            string directoryPath = @"F:\D\music\Adele\Adele - 30";


            string[] files = Directory.GetFiles(directoryPath);
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo fi = new FileInfo(files[i]);
                long size = fi.Length;
                Interlocked.Add(ref totalSize, size);
            };

            Console.WriteLine($"For Directory '{directoryPath}':");
            Console.WriteLine($"{files.Length:N0} files, {totalSize:N0} bytes");
        }

    }
    
}
