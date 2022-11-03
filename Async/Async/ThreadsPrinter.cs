using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    internal static class ThreadsPrinter
    {
        static object locker = new();  // объект-заглушка
                                       // запускаем пять потоков
        static int x = 0;
        static int id = 0;
        public static void RunThread()
        {
            for (int i = 1; i < 6; i++)
            {
                Thread myThread = new(Print);
                myThread.Name = $"Поток {i}";
                myThread.Start();
            }
        }


        public static void RunTask()
        {
            for (int i = 1; i < 6; i++)
            {
                Task task = new(Print);
                id = task.Id;   
                task.Start();
                task.Wait();
            }
        }

        private static void Print()
        {
            lock (locker)
            {
                x = 1;
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine($"Task {id} : Thread id {Thread.CurrentThread.ManagedThreadId} : {x}");
                    x++;
                    Thread.Sleep(100);
                }
            }
        }

    }
}
