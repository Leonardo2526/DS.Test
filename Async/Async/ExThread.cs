using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    // C# program to illustrate the
    // concept of Abort() method
    // on a single thread
    using System;
    using System.Threading;

    class ExThread
    {

        public Thread thr;

        public ExThread(string name)
        {
            thr = new Thread(this.RunThread);
            thr.Name = name;
            thr.Start();
        }

        // Enetring point for thread
        void RunThread()
        {
            try
            {
                Console.WriteLine(thr.Name +
                            " is starting.");

                for (int j = 1; j <= 100; j++)
                {
                    Console.Write(j + " ");
                    if ((j % 10) == 0)
                    {
                        Console.WriteLine();
                        Thread.Sleep(200);
                    }
                }
                Console.WriteLine(thr.Name +
                      " exiting normally.");
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine("Thread is aborted and the code is "
                                                 + ex.ExceptionState);
            }
        }
    }

    // Driver Class
    public static class ThreadExample
    {

        // Main method
        public static void Run()
        {

            // Creating object of ExThread
            ExThread obj = new ExThread("Thread ");
            Thread.Sleep(1000);
            Console.WriteLine("Stop thread");
            //obj.thr.Abort(10);

            // Waiting for a thread to terminate.
            obj.thr.Join();
            Console.WriteLine("Main thread is terminating");
        }
    }
}
