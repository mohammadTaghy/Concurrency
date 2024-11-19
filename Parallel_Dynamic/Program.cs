using System.Diagnostics;
using System.Xml.Linq;

namespace Parallel_Dynamic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        void Traverse(Node current)
        {
            DoExpensiveActionOnNode(current);
            if (current.Left != null)
            {
                Task.Factory.StartNew(
                () => Traverse(current.Left),
                CancellationToken.None,
                TaskCreationOptions.AttachedToParent,
                TaskScheduler.Default);
            }
            if (current.Right != null)
            {
                Task.Factory.StartNew(
                () => Traverse(current.Right),
                CancellationToken.None,
                TaskCreationOptions.AttachedToParent,
                TaskScheduler.Default);
            }
        }
        async Task ProcessTree(Node root)
        {
            Task task = Task.Factory.StartNew(
            () => Traverse(root),
            CancellationToken.None,
            TaskCreationOptions.None,
            TaskScheduler.Default);
            await task;
        }
        void DoExpensiveActionOnNode(Node root)
        {
            Task.Delay(1000);
        }
        //--------------------------------------------------------------

        void AnotherExapmle()
        {
            Task task = Task.Factory.StartNew(
                 () => Thread.Sleep(TimeSpan.FromSeconds(2)),
                 CancellationToken.None,
                 TaskCreationOptions.None,
                 TaskScheduler.Default);
            Task continuation = task.ContinueWith(
             t => Trace.WriteLine("Task is done"),
             CancellationToken.None,
             TaskContinuationOptions.None,
             TaskScheduler.Default);
        }


    }
    public class Node
    {
        public Node Right { get; set; }
        public Node Left { get; set; }
    }
}
