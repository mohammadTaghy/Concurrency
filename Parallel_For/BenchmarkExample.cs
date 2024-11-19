using BenchmarkDotNet.Attributes;

namespace Parallel_For
{
    public class BenchmarkExample
    {
        [Benchmark]
        public void UseParallelForeach()
        {
            string directoryPath = @"F:\D\music\Adele\Adele - 30";


            string[] files = Directory.GetFiles(directoryPath);
            Parallel.ForEach(files, file =>
            {
                FileInfo fi = new FileInfo(file);
                long size = fi.Length;
                string content = File.ReadAllText(file);
            });

        }
        [Benchmark]
        public  void UseParallelFor()
        {
            string directoryPath = @"F:\D\music\Adele\Adele - 30";


            string[] files = Directory.GetFiles(directoryPath);
            Parallel.For(0, files.Length, index =>
            {
                FileInfo fi = new FileInfo(files[index]);
                long size = fi.Length;
                string content = File.ReadAllText(files[index]);
            });

        }
        [Benchmark]
        public  void UselFor()
        {
            string directoryPath = @"F:\D\music\Adele\Adele - 30";


            string[] files = Directory.GetFiles(directoryPath);
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo fi = new FileInfo(files[i]);
                long size = fi.Length;
                string content = File.ReadAllText(files[i]);
            };

        }
    }
}
