using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async.CancelTests

{
    internal class TestTasks
    {
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

        public static async Task CreateTaskAsync(CancellationToken cancelTok)
        {
            cancelTok.ThrowIfCancellationRequested();

            Console.WriteLine("MyTask() №{0} в потоке {1} запущен", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);

            for (int count = 0; count < 10; count++)
            {
                //Используем опрос

                cancelTok.ThrowIfCancellationRequested();

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
            catch(Exception ex)
            {

            }
        }

    }
}
