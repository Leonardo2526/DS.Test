using DS.ConsoleApp.MultithreadTest.DeadLockTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DS.ConsoleApp.MultithreadTest
{
    internal static class CounterTest
    {
        static int Count = 0;

        internal static void Run()
        {
            Thread t1 = new Thread(IncrementCount);
            Thread t2 = new Thread(IncrementCount);
            Thread t3 = new Thread(IncrementCount);
            t1.Start();
            t2.Start();
            t3.Start();

            //Wait for all three threads to complete their execution
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine(Count);
        }

        private static readonly object LockCount = new object();
        static void IncrementCount()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                //Count++;

                //Only protecting the shared Count variable
                lock (LockCount)
                {
                    Count++;
                }
            }
        }
    }
}
