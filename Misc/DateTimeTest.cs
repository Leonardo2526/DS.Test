using DS.ClassLib.VarUtils;
using Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Misc
{
    internal class DateTimeTest
    {
        public static void Run()
        {
            DateTime date1 = DateTime.Now;
            Console.WriteLine(date1);
            Thread.Sleep(150);
            DateTime date2 = DateTime.Now;

            // Calculate the interval between the two dates.
            TimeSpan interval = date2 - date1;
            Console.WriteLine("{0} {1,0:N0}ms", "Value of Milliseconds Component:", interval.TotalMilliseconds);
        }

        public static void RunDelegate()
        {

           var span = TimeSpanRunner.Run(() => Thread.Sleep(150));
            var ms = (int)span.TotalMilliseconds;
            Console.WriteLine(ms);
        }
    }

}
