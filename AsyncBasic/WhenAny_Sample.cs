using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncBasic
{
    internal class WhenAny_Sample
    {
        async Task<int> FirstRespondingUrlAsync(HttpClient client,string urlA, string urlB)
        {
            // Start both downloads concurrently.
            Task<byte[]> downloadTaskA = client.GetByteArrayAsync(urlA);
            Task<byte[]> downloadTaskB = client.GetByteArrayAsync(urlB);
            // Wait for either of the tasks to complete.
            Task<byte[]> completedTask =
            await Task.WhenAny(downloadTaskA, downloadTaskB);
            // Return the length of the data retrieved from that URL.
            byte[] data = await completedTask;
            return data.Length;
        }
        // show all result
        async Task ProcessTasksAsync()
        {
            // Create a sequence of tasks.
            Task<int> taskA = DelayAndReturnAsync(2);
            Task<int> taskB = DelayAndReturnAsync(3);
            Task<int> taskC = DelayAndReturnAsync(1);
            Task<int>[] tasks = new[] { taskA, taskB, taskC };
            // Await each task in order.
            foreach (Task<int> task in tasks)
            {
                var result = await task;
                Trace.WriteLine(result);
            }
        }
        async Task<int> DelayAndReturnAsync(int value)
        {
            await Task.Delay(TimeSpan.FromSeconds(value));
            return value;
        }
        //better solution
        async Task<int> DelayAndReturnAsync_better(int value)
        {
            await Task.Delay(TimeSpan.FromSeconds(value));
            return value;
        }
        async Task AwaitAndProcessAsync(Task<int> task)
        {
            int result = await task;
            Trace.WriteLine(result);
        }
        // This method now prints "1", "2", and "3".
        async Task ProcessTasksAsync_better()
        {
            // Create a sequence of tasks.
            Task<int> taskA = DelayAndReturnAsync_better(2);
            Task<int> taskB = DelayAndReturnAsync_better(3);
            Task<int> taskC = DelayAndReturnAsync_better(1);
            Task<int>[] tasks = new[] { taskA, taskB, taskC };
            IEnumerable<Task> taskQuery =
            from t in tasks select AwaitAndProcessAsync(t);
            Task[] processingTasks = taskQuery.ToArray();
            // Await all processing to complete
            await Task.WhenAll(processingTasks);
        }


    }
}
