﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace DS.ConsoleApp.MultithreadTest.CancelTests

{
    internal class TestTask
    {
        public CancellationTokenSource InnerSource { get; private set; }
        public CancellationTokenSource TotalSource { get; private set; }
        public Task Task { get; set; }

        public TestTask(CancellationTokenSource innerSource, CancellationTokenSource totalSource = null)
        {
            this.InnerSource = innerSource;
            this.TotalSource = totalSource;
        }

        public TestTask(CancellationTokenSource totalSource = null)
        {
            this.TotalSource = totalSource;
        }

        public static void CreateTask1(CancellationToken cancelTok)
        {
            cancelTok.ThrowIfCancellationRequested();

            Console.WriteLine("MyTask() №{0} запущен", Task.CurrentId);

            for (int count = 0; count < 10; count++)
            {
                // Используем опрос
                if (!cancelTok.IsCancellationRequested)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("В методе MyTask №{0} подсчет равен {1}", Task.CurrentId, count);
                }
            }

        }

        public static void CreateTaskWithOperationCanceledException(CancellationToken cancelTok)
        {
            cancelTok.ThrowIfCancellationRequested();

            Console.WriteLine("MyTask() №{0} запущен", Task.CurrentId);

            for (int count = 0; count < 10; count++)
            {
                // Используем опрос
                cancelTok.ThrowIfCancellationRequested();

                Thread.Sleep(500);
                Console.WriteLine("В методе MyTask №{0} подсчет равен {1}", Task.CurrentId, count);

            }

        }

        public async Task CreateTaskAsync(CancellationToken cancelTok)
        {
            //Используем опрос
            cancelTok.ThrowIfCancellationRequested();
            //InnerCancellationToken.Token.ThrowIfCancellationRequested();

            Console.WriteLine("MyTask() №{0} в потоке {1} запущен", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);

            for (int count = 0; count < 10; count++)
            {
                //Используем опрос
                cancelTok.ThrowIfCancellationRequested();
                //InnerCancellationToken.Token.ThrowIfCancellationRequested();

                await Task.Delay(500);
                Console.WriteLine("В методе MyTask №{0} подсчет равен {1}. Поток {2}",
                    Task.CurrentId, count, Thread.CurrentThread.ManagedThreadId);

                //if (!cancelTok.IsCancellationRequested)
                //{
                //    await Task.Delay(500);
                //    Console.WriteLine("В методе MyTask №{0} подсчет равен {1}", Task.CurrentId, count);
                //}

            }

        }

        private static object lockObject = new object();

        public async Task CreateTaskAsync()
        {
            Console.WriteLine($"MyTask №{Task.CurrentId} в потоке {Thread.CurrentThread.ManagedThreadId} запущен");

            Task task = Task.Run(() =>
            {

                lock (lockObject)
                {
                    for (int count = 0; count < 10; count++)
                    {
                        //Используем опрос
                        if (TotalSource is not null)
                        {
                            TotalSource.Token.ThrowIfCancellationRequested();
                        }
                        InnerSource?.Token.ThrowIfCancellationRequested();

                        Task.Delay(100).Wait();
                        //lock (lockObject)
                        {
                            Console.WriteLine($"В методе MyTask №{Task.CurrentId} подсчет равен {count}. Поток {Thread.CurrentThread.ManagedThreadId}");

                        }
                    }
                }
            });
            await task;
        }

        public async Task CreateTaskAsync1()
        {
            InnerSource = new CancellationTokenSource();
            Console.WriteLine("MyTask() №{0} в потоке {1} запущен", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);

            for (int count = 0; count < 10; count++)
            {
                await GetTask(count);
            }
        }

        private async Task GetTask(int count)
        {
            await Task.Delay(100);
            Console.WriteLine($"В методе MyTask №{Task.CurrentId} подсчет равен {count}. " +
                $"Поток {Thread.CurrentThread.ManagedThreadId}");
        }


        public static void CreateAgregateException()
        {
            var task1 = Task.Run(() => { throw new AggregateException("This exception is expected!"); });

            try
            {
                task1.Wait();
            }
            catch (AggregateException agEx)
            {
                Console.WriteLine("AggregateException" + agEx.InnerException.Message + " " + agEx.Message);
                agEx.Handle((x) =>
                {
                    Console.WriteLine("new");
                    return false; // Let anything else stop the application.
                });
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<int> CreateTaskAsync2()
        {
            InnerSource = new CancellationTokenSource();
            Console.WriteLine("MyTask() №{0} в потоке {1} запущен", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
            int count = 0;
            for (count = 0; count < 10; count++)
            {
                if(count == 5) 
                { InnerSource.Cancel(); }
                InnerSource.Token.ThrowIfCancellationRequested();
                await Task.Delay(300);
                Console.WriteLine($"В методе MyTask №{Task.CurrentId} подсчет равен {count}. Поток {Thread.CurrentThread.ManagedThreadId}");
            }

            return count;
        }

    }
}
