using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DS.WpfApp.MetroTest
{
    internal class Model2
    {
        public static async Task<decimal> LongRunningOperationWithCancellationTokenAsync(int loop, CancellationToken cancellationToken)
        {
            // We create a TaskCompletionSource of decimal
            var taskCompletionSource = new TaskCompletionSource<decimal>();

            // Registering a lambda into the cancellationToken
            cancellationToken.Register(() =>
            {
                // We received a cancellation message, cancel the TaskCompletionSource.Task
              taskCompletionSource.TrySetCanceled();
            
            });

            var task = LongRunningOperation(loop);

            // Wait for the first task to finish among the two
            var completedTask = await Task.WhenAny(task, taskCompletionSource.Task);

            return await completedTask;
        }

        public static async Task LongRunningOperationWithCancellationTokenAsync1(int loop, CancellationToken cancellationToken)
        {
            // We create a TaskCompletionSource of decimal
            var taskCompletionSource = new TaskCompletionSource<decimal>();

            // Registering a lambda into the cancellationToken
            cancellationToken.Register(() =>
            {
                // We received a cancellation message, cancel the TaskCompletionSource.Task
               taskCompletionSource.TrySetCanceled();
            });

            var task = LongRunningOperation(loop);

            try
            {
                // Wait for the first task to finish among the two
                var completedTask = await Task.WhenAny(task, taskCompletionSource.Task);
                MessageBox.Show("Task is done");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Process stopped manually");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error");
            }

        }

        /// <summary>
        /// Compute a value for a long time.
        /// </summary>
        /// <returns>The value computed.</returns>
        /// <param name="loop">Number of iterations to do.</param>
        public static Task<decimal> LongRunningOperation(int loop)
        {
            // Start a task and return it
            return Task.Run(() =>
            {
                decimal result = 0;

                // Loop for a defined number of iterations
                for (int i = 0; i < loop; i++)
                {
                    // Do something that takes times like a Thread.Sleep in .NET Core 2.
                    Thread.Sleep(10);
                    result += i;
                }

                return result;
            });
        }
    }
}
