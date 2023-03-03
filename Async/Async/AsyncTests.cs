using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    internal static class AsyncTests
    {
        public static void Test1()
        {
            Console.WriteLine(nameof(Test1) + " started!");

            AsyncMethod1().Wait();

            Console.WriteLine(nameof(Test1) + " completed!");
        }


        private static async Task AsyncMethod1()
        {
            Console.WriteLine($"\nWaiting for {nameof(AsyncMethod1)}...");
            await Task.Delay(1);
            Console.WriteLine(nameof(AsyncMethod1) + " completed!");
            Console.WriteLine();
        }
    }
}
