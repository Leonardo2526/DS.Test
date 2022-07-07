using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async.CancelTests

{
    internal class TestTasks
    {
        public static void CreateTask1(CancellationToken cancelTok)
        {
            cancelTok.ThrowIfCancellationRequested();

            Console.WriteLine("MyTask() №{0} запущен", Task.CurrentId);

            for (int count = 0; count < 10; count++)
            {
                // Используем опрос
                if (!cancelTok.IsCancellationRequested)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("В методе MyTask №{0} подсчет равен {1}", Task.CurrentId, count);
                }
            }

        }

    }
}
