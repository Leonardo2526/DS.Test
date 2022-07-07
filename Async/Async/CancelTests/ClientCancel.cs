using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async.CancelTests
{
    internal static class ClientCancel
    {
        public static void Run()
        {

            Console.WriteLine("Основной поток запущен");

            // Объект источника признаков отмены
            CancellationTokenSource cancelTokSSrc = new CancellationTokenSource();

            // Запустить задачу, передав ей признак отмены
            Task tsk = Task.Factory.StartNew(p => TestTasks.CreateTask1(cancelTokSSrc.Token), cancelTokSSrc.Token);

            Thread.Sleep(2000);
            try
            {
                // отменить задачу
                cancelTokSSrc.Cancel();
                tsk.Wait();
            }
            catch (AggregateException exc)
            {
                //if (tsk.IsCanceled)
                Console.WriteLine("Задача tsk отменена");
            }
            finally
            {
                tsk.Dispose();
                cancelTokSSrc.Dispose();
            }

            Console.WriteLine("Основной поток завершен");
            Console.ReadLine();

        }

        public static void RunWithOperationCanceledException()
        {

            Console.WriteLine("Основной поток запущен");

            // Объект источника признаков отмены
            CancellationTokenSource cancelTokSSrc = new CancellationTokenSource();

            // Запустить задачу, передав ей признак отмены
            Task tsk = Task.Factory.StartNew(p =>
            TestTasks.CreateTaskWithOperationCanceledException(cancelTokSSrc.Token), cancelTokSSrc.Token);

            Thread.Sleep(2000);
            try
            {
                // отменить задачу
                cancelTokSSrc.Cancel();
                tsk.Wait();
            }
            catch (OperationCanceledException)
            {
                if (tsk.IsCanceled)
                    Console.WriteLine("Задача tsk отменена");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                // Normal error handling; log, etc.
            }
            finally
            {
                tsk.Dispose();
                cancelTokSSrc.Dispose();
            }

            Console.WriteLine("Основной поток завершен");
            Console.ReadLine();

        }

        public static async Task RunAsync()
        {
            CancellationTokenSource cancelTokSSrc = new CancellationTokenSource();

            Task tsk = Task.Run(() => TestTasks.CreateTaskAsync(cancelTokSSrc.Token));

            Thread.Sleep(2000);

            try
            {
                // отменить задачу
                cancelTokSSrc.Cancel();
                await tsk;
            }
            catch (OperationCanceledException opEx)
            {
                // Special cancellation handling
                Console.WriteLine($"OperationCanceledException - {opEx.Message}");
            }
            catch (Exception ex)
            {
                // Normal error handling; log, etc.
                Console.WriteLine("Exception - " + ex.Message);
            }
            finally
            {
                tsk.Dispose();
                cancelTokSSrc.Dispose();
            }

            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} завершен");
        }
    }
}
