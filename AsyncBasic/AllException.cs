using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncBasic
{
    internal class AllException
    {
        async Task ThrowNotImplementedExceptionAsync()
        {
            throw new NotImplementedException();
        }
        async Task ThrowInvalidOperationExceptionAsync()
        {
            throw new InvalidOperationException();
        }
        async Task ObserveOneExceptionAsync()
        {
            var task1 = ThrowNotImplementedExceptionAsync();
            var task2 = ThrowInvalidOperationExceptionAsync();
            try
            {
                await Task.WhenAll(task1, task2);
            }
            catch (Exception ex)
            {
                // "ex" is either NotImplementedException or InvalidOperationException.
            }
        }
        async Task ObserveAllExceptionsAsync()
        {
            var task1 = ThrowNotImplementedExceptionAsync();
            var task2 = ThrowInvalidOperationExceptionAsync();
            Task allTasks = Task.WhenAll(task1, task2);
            try
            {
                await allTasks;
            }
            catch
            {
                AggregateException allExceptions = allTasks.Exception;
            }
        }

    }
}
