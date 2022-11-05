using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    internal class Printer
    {
        public void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}, Task: {Task.CurrentId}. i = {i}");
            }
        }
    }
}
