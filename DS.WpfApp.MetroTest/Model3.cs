using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DS.WpfApp.MetroTest
{
    internal static class Model3
    {
        public static async Task<TResult> TimeoutAfter<TResult>(this Task<TResult> task, TimeSpan timeout)
        {
            // We need to be able to cancel the "timeout" task, so create a token source
            var cts = new CancellationTokenSource();

            // Create the timeout task (don't await it)
            var timeoutTask = Task<TResult>.Delay(timeout, cts.Token);

            // Run the task and timeout in parallel, return the Task that completes first
            var completedTask = await Task<TResult>.WhenAny(task, timeoutTask).ConfigureAwait(false);

            if (completedTask == task)
            {
                // Cancel the "timeout" task so we don't leak a Timer
                cts.Cancel();
                // await the task to bubble up any errors etc
                return await task.ConfigureAwait(false);
            }
            else
            {
                throw new TimeoutException($"Task timed out after {timeout}");
            }
        }

        public static async Task<int> SomeWork(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested(); /* 1 */
            try
            {
                await Task.Run(async () =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
                });
                MessageBox.Show("Task is done");
            }
            catch(OperationCanceledException)
            {
                //MessageBox.Show("Handled");
            }


            //cancellationToken.ThrowIfCancellationRequested(); /* 2 */
            //while (true)
            //{
            //    // Что-то делаем
            //    cancellationToken.ThrowIfCancellationRequested();
            //}
            return 42;
        }
    }
}
