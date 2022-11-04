using DS.ConsoleApp.MultithreadTest.DeadLockTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DS.ConsoleApp.MultithreadTest
{
    internal static  class DeadLockTest
    {
        public static void Run()
        {
            Console.WriteLine("Main Started");
            Account accountA = new Account(101, 5000);
            Account accountB = new Account(102, 3000);

            AccountManager accountManagerA = new
                AccountManager(accountA, accountB, 1000);
            Thread T1 = new Thread(accountManagerA.Transfer_DeadLock);
            T1.Name = "T1";

            AccountManager accountManagerB = new
                AccountManager(accountB, accountA, 2000);
            Thread T2 = new Thread(accountManagerB.Transfer_DeadLock);
            T2.Name = "T2";

            T1.Start();
            T2.Start();

            T1.Join();
            T2.Join();
            Console.WriteLine("Main Completed");
        }
    }
}
