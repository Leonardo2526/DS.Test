using DS.ClassLib.VarUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DS.ConsoleApp.MultithreadTest
{
    internal static class LongOperationTest
    {
        public static void Run()
        {
            Task<string> t1= Task.Run(() => OperationCreator.LongOperation(new CancellationTokenSource(), null));
            t1.Wait();
            Console.WriteLine("1-" + t1.Result);

            Task<string> t2 = Task.Run(() => OperationCreator.LongOperation(new CancellationTokenSource(), null));
            t2.Wait();
            Console.WriteLine("2-" + t2.Result);
        }
    }
}
