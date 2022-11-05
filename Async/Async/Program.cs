using DS.ConsoleApp.MultithreadTest.CancelTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DS.ConsoleApp.MultithreadTest
{
    class Program
    {
        //DS.ConsoleApp.MultithreadTest static Task Main(string[] args)
        //{
        //    //HTMLLoader.Load();
        //    await NamePrinter.PrintAwait();
        //    //await NamePrinter.PrintAwait1();
        //    //await NamePrinter.PrintNoAwait();
        //    //await NamePrinter.PrintNameWithRun();
        //    //NamePrinter.PrintNameWithRun1();

        //    Console.ReadLine();
        //}


        static void Main1(string[] args)
        {
            TaskTest.RunPrintNumbers();
            //TaskTest.RunAndWaitMultipleTasks_InterLocked();
            //ThreadsPrinter.RunTask();
            //DeadLockTest.Run();
            //CounterTest.Run();

            Console.ReadLine();
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} из Main запущен\n");

           Task task1 = new TestTask().CreateTaskAsync();
           Task task2 = new TestTask().CreateTaskAsync();
           Task task3 = new TestTask().CreateTaskAsync();
           await Task.WhenAll(task1, task2, task3);

            //Task task2 = Task.Run(() => ClientCancel.RunDS.ConsoleApp.MultithreadTest());
            //Thread.Sleep(2000);
            //await task2;

            Console.WriteLine($"\nПоток {Thread.CurrentThread.ManagedThreadId} из Main завершен");

            Console.ReadLine();
        }

    }
}
