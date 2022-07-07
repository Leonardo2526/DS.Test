using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async.CancelTests
{
    internal static class Handler
    {
        public static async Task HandleException(Task task, CancellationTokenSource cancelTokSSrc)
        {
            try
            {
                // отменить задачу
                cancelTokSSrc.Cancel();
                await task;
            }
            catch (OperationCanceledException opEx)
            {
                // Special cancellation handling
                Console.WriteLine($"OperationCanceledException - {opEx.Message} Task id: {task.Id}. " +
                    $"Поток: {Thread.CurrentThread.ManagedThreadId}");
            }
            catch (Exception ex)
            {
                // Normal error handling; log, etc.
                Console.WriteLine("Exception - " + ex.Message);
            }
            finally
            {
                task.Dispose();
                cancelTokSSrc.Dispose();
            }
        }
    }
}
