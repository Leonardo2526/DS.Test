using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DS.ConsoleApp.MultithreadTest.CancelTests
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
            Task tsk = Task.Factory.StartNew(p => TestTask.CreateTask1(cancelTokSSrc.Token), cancelTokSSrc.Token);

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
            TestTask.CreateTaskWithOperationCanceledException(cancelTokSSrc.Token), cancelTokSSrc.Token);

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
            List<TestTask> testTasks = new List<TestTask>();
            List<CancellationTokenSource> cancellationTokenSources = new List<CancellationTokenSource>();

            CancellationTokenSource totalToketSource = new CancellationTokenSource();
            //CancellationTokenSource totalToketSource = null;

            //TestTasks testTasks1 = new TestTasks(task1TokenSource, totalToketSource);
            TestTask testTasks1 = new TestTask(totalToketSource);
            Task task1 = Task.Run(() => testTasks1.CreateTaskAsync1());
            testTasks1.Task = task1;

            //TestTasks testTasks2 = new TestTasks(task2TokenSource, totalToketSource);
            TestTask testTasks2 = new TestTask(totalToketSource);
            Task task2 = Task.Run(() => testTasks2.CreateTaskAsync1());
            testTasks2.Task = task2;

            testTasks.Add(testTasks1);
            testTasks.Add(testTasks2);
            tasks.Add(task1);
            tasks.Add(task2);

            Thread.Sleep(2000);

            //await CancelTest(testTasks1);
            //await CancelTest(testTasks2);

            //await CancelAllTestTasks(testTasks);
            //await CancelAllTestTasksByTotal(testTasks);
            //await CancelAllTestTasksByInner(testTasks);

            //Task.WaitAll(tasks.ToArray());

            totalToketSource.Dispose();

            Console.WriteLine($"\nПоток {Thread.CurrentThread.ManagedThreadId} завершен");
        }


        private static async Task CancelAllTestTasks(List<TestTask> testTasks)
        {
            foreach (var testTask in testTasks)
            {
                await CancelTest(testTask);
            }
        }

        private static async Task CancelAllTestTasksByTotal(List<TestTask> testTasks)
        {
            foreach (var testTask in testTasks)
            {
                    await Cancel.CancelTask(testTask.Task, testTask.TotalSource, "TotalSource");
             
            }
        }

        private static async Task CancelAllTestTasksByInner(List<TestTask> testTasks)
        {
            foreach (var testTask in testTasks)
            {
                await Cancel.CancelTask(testTask.Task, testTask.InnerSource, "InnerSource");
                testTask.InnerSource.Dispose();
            }
        }


        private static async Task CancelTest(TestTask testTask)
        {
            if (testTask.TotalSource is null)
            {
                await Cancel.CancelTask(testTask.Task, testTask.InnerSource, "InnerSource");
                testTask.InnerSource.Dispose();
            }
            else
            {
                await Cancel.CancelTask(testTask.Task, testTask.TotalSource, "TotalSource");
            }
        }

    }
}
