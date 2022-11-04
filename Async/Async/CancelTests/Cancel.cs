using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DS.ConsoleApp.MultithreadTest.CancelTests
{
    internal static class Cancel
    {
        public static async Task CancelTask(Task task, CancellationTokenSource cancelTokSSrc, string tokenDiscription)
        {
            try
            {
                cancelTokSSrc.Cancel();
                await task;
            }
            catch (OperationCanceledException opEx)
            {
                Console.WriteLine($"OperationCanceledException: {opEx.Message} Token: {tokenDiscription}. Task id: {task.Id}. " +
                    $"Поток: {Thread.CurrentThread.ManagedThreadId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception - " + ex.Message);
            }
            finally
            {
                task.Dispose();
            }
        }
    }
}
