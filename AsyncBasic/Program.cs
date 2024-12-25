namespace AsyncBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        public Task<int> GetValueAsync()
        {
            return Task.FromResult(13);
        }
        public Task DoSomethingAsync()
        {
            return Task.CompletedTask;
        }
        Task<T> NotImplementedAsync<T>()
        {
            return Task.FromException<T>(new NotImplementedException());
        }
        Task<int> GetValueAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return Task.FromCanceled<int>(cancellationToken);
            return Task.FromResult(13);
        }
        public Task DoSomethingAsyncWithTry()
        {
            try
            {
                DoSomethingSynchronously();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
        public Task DoSomethingSynchronously()
        {
            return Task.CompletedTask;
        }
        async Task<string> DownloadAllAsync(HttpClient client,IEnumerable<string> urls)
        {
            // Define the action to do for each URL.
            var downloads = urls.Select(url => client.GetStringAsync(url));
            // Note that no tasks have actually started yet
            // because the sequence is not evaluated.
            // Start all URLs downloading simultaneously.
            Task<string>[] downloadTasks = downloads.ToArray();
            // Now the tasks have all started.
            // Asynchronously wait for all downloads to complete.
            string[] htmlPages = await Task.WhenAll(downloadTasks);
            return string.Concat(htmlPages);
        }

    }
}
