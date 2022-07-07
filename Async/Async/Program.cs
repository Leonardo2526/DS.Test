using Async.CancelTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            TestTasks.CreateAgregateException();
            //ThreadExample.Run();

            Console.ReadLine();
        }

        static async Task Main(string[] args)
        {
          
           await ClientCancel.RunAsync();

            Console.ReadLine();
        }

    }
}
