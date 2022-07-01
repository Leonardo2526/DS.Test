using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    internal static class NamePrinter
    {
        public static void PrintSync()
        {
            PrintNoAwait();
            Console.WriteLine("");
        }

        public static async Task PrintAwait()
        {
            await PrintNameAsync("Tom");
            await PrintNameAsync("Bob");
            await PrintNameAsync("Sam");
        }

        public static async Task PrintAwait1()
        {
            PrintName("Tom");
            PrintName("Bob");
            PrintName("Sam");
        }

        public static async Task PrintNoAwaitWithTask()
        {
            var tomTask = PrintNameAsync("Tom");
            var bobTask = PrintNameAsync("Bob");
            var samTask = PrintNameAsync("Sam");

            await tomTask;
            await bobTask;
            await samTask;
        }

        public static async void PrintNoAwait()
        {
            var tomTask = PrintNameAsync("Tom");
            var bobTask = PrintNameAsync("Bob");
            var samTask = PrintNameAsync("Sam");

            await tomTask;
            await bobTask;
            await samTask;
        }

        public static async Task PrintNameWithRun()
        {
            await Task.Run(() =>
                {
                    PrintName("name1");
                    PrintName("name2");
                    PrintName("name3");
                });
        }

        // определение асинхронного метода
        static async Task PrintNameAsync(string name)
        {
            await Task.Delay(3000);     // имитация продолжительной работы
            Console.WriteLine(name);
        }


        static void PrintName(string name)
        {
            Task.Delay(3000);     // имитация продолжительной работы
            Console.WriteLine(name);
        }
    }
}
