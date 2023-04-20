using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DS.ConsoleApp.MultithreadTest.CancelTests
{
    internal static class TokenCatcher
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

        public static async Task<int> Catch1(Func<Task<int>> task, CancellationTokenSource cancelTokSSrc = null, string tokenDiscription = "token")
        {
            try
            {
                await task();
            }
            catch (OperationCanceledException opEx)
            {
                Console.WriteLine($"OperationCanceledException: {opEx.Message} Token: {tokenDiscription}. Task id: {task().Id}. " +
                    $"Поток: {Thread.CurrentThread.ManagedThreadId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception - " + ex.Message);
            }
            finally
            {
                //task.Dispose();
            }
                return 0;
        }
    }
}
