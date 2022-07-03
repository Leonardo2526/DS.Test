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
            //Task.Run(() => PrintName("Tom"));
            PrintDelayName("Tom");
            await Task.Run(() => PrintName("Bob"));
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

        public static async Task PrintNoAwait()
        {
            List<Task> tasks = new List<Task>();

            tasks.Add(PrintNameAsync("Tom"));
            tasks.Add(PrintNameAsync("Bob"));
            tasks.Add(PrintNameAsync("Sam"));

            await Task.WhenAll(tasks);
        }

        public static async Task PrintNameWithRun()
        {
            await Task.Run(() =>
                {
                    PrintDelayName("name1");
                    PrintDelayName("name2");
                    PrintDelayName("name3");
                });
        }

        public static async void PrintNameWithRun1()
        {
            await Task.Run(() =>
            {
                PrintDelayName("name1");
                PrintDelayName("name2");
                PrintDelayName("name3");
            });
        }

        // определение асинхронного метода
        static async Task PrintNameAsync(string name)
        {
            await Task.Delay(3000);     // имитация продолжительной работы
            Console.WriteLine(name);
        }


        static void PrintDelayName(string name)
        {
            Task.Delay(3000);     // имитация продолжительной работы
            Console.WriteLine(name);
            for (int i = 0; i < 10000000; i++)
            {
                string s = i.ToString();
            }
            Console.WriteLine(name + "1");
            Console.WriteLine(name + "2");
        }

        static void PrintName(string name)
        {
            Task.Delay(3000);     // имитация продолжительной работы
            Console.WriteLine(name);
            Console.WriteLine(name + "1");
            Console.WriteLine(name + "2");
        }
    }
}
