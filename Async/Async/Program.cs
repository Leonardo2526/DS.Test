using Async;
using DS.ConsoleApp.MultithreadTest.CancelTests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DS.ConsoleApp.MultithreadTest
{
    class Program
    {       
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Main started.");

        //    AsyncTests.Test1();

        //    Console.WriteLine("Main completed.");

        //    Console.ReadLine();
        //}

        static async Task Main(string[] args)
        {
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} из Main запущен\n");

            var t = new TestTask();
            var task2 = t.CreateTaskAsync2();
                await TokenCatcher.Catch1(async () => await task2);          
            //try
            //{
            //}
            //catch (OperationCanceledException opEx)
            //{
            //    Console.WriteLine($"OperationCanceledException");
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}



           //Task task1 = new TestTask().CreateTaskAsync1();
           //Task task2 = new TestTask().CreateTaskAsync1();
           //Task task3 = new TestTask().CreateTaskAsync1();
           //await Task.WhenAll(task1, task2, task3);

            //Task task2 = Task.Run(() => ClientCancel.RunDS.ConsoleApp.MultithreadTest());
            //Thread.Sleep(2000);
            //await task2;

            Console.WriteLine($"\nПоток {Thread.CurrentThread.ManagedThreadId} из Main завершен");
            //Console.WriteLine($"\nПоток {task2.Result}");

            Console.ReadLine();
        }

    }
}
