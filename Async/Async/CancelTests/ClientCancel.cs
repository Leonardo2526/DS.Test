using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Async.CancelTests
{
    internal static class ClientCancel
    {
        //public static List<Task> tasks;

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
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} запущен\n");


            List<Task> tasks = new List<Task>();
            List<TestTasks> testTasks = new List<TestTasks>();
            List<CancellationTokenSource> cancellationTokenSources = new List<CancellationTokenSource>();

            CancellationTokenSource totalToketSource = new CancellationTokenSource();

            CancellationTokenSource task1TokenSource = new CancellationTokenSource();
            TestTasks testTasks1 = new TestTasks(task1TokenSource, totalToketSource);
            Task task1 = Task.Run(() => testTasks1.CreateTaskAsync());
            testTasks1.Task = task1;

            CancellationTokenSource task2TokenSource = new CancellationTokenSource();
            TestTasks testTasks2 = new TestTasks(task2TokenSource, totalToketSource);
            Task task2 = Task.Run(() => testTasks2.CreateTaskAsync());
            testTasks2.Task = task2;

            testTasks.Add(testTasks1);
            testTasks.Add(testTasks2);
            tasks.Add(task1);
            tasks.Add(task2);

            Thread.Sleep(2000);

            //await CancelTest(testTasks1);
            //await CancelTest(testTasks2);

            //await CancelAllTasksOneByOne(testTasks);
            await CancelAllTasks(tasks, totalToketSource);

            Console.WriteLine($"\nПоток {Thread.CurrentThread.ManagedThreadId} завершен");
        }


        private static async Task CancelAllTasks(List<Task> tasks, CancellationTokenSource totalToketSource)
        {
            foreach (var task in tasks)
            {
                await Cancel.CancelTask(task, totalToketSource);
            }
        }

        private static async Task CancelAllTasksOneByOne(List<TestTasks> testTasks)
        {
            foreach (var testTask in testTasks)
            {
                await Cancel.CancelTask(testTask.Task, testTask.InnerSource);
            }
        }


        private static async Task CancelTest(TestTasks testTasks)
        {
            if (testTasks.TotalSource is null)
            {
                await Cancel.CancelTask(testTasks.Task, testTasks.InnerSource);
            }
            else
            {
                await Cancel.CancelTask(testTasks.Task, testTasks.TotalSource);
            }
        }

    }
}
