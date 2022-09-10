using Async.CancelTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        //async static Task Main(string[] args)
        //{
        //    //HTMLLoader.Load();
        //    await NamePrinter.PrintAwait();
        //    //await NamePrinter.PrintAwait1();
        //    //await NamePrinter.PrintNoAwait();
        //    //await NamePrinter.PrintNameWithRun();
        //    //NamePrinter.PrintNameWithRun1();

        //    Console.ReadLine();
        //}


        static void Main0(string[] args)
        {
            //ClientCancel.Run();
            //ClientCancel.RunWithOperationCanceledException();
            TestTask.CreateAgregateException();
            //ThreadExample.Run();

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            LongOperationTest.Run();

            //TasksIterator.Run();

            Console.ReadLine();
        }

        static async Task Main1(string[] args)
        {
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} из Main запущен\n");

            await ClientCancel.RunAsync();

            //Task task2 = Task.Run(() => ClientCancel.RunAsync());
            //Thread.Sleep(2000);
            //await task2;

            Console.WriteLine($"\nПоток {Thread.CurrentThread.ManagedThreadId} из Main завершен");

            Console.ReadLine();
        }

    }
}
