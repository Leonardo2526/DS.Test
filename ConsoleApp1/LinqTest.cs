using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.Net6Test
{
    internal static class LinqTest
    {
        public static void Foreach()
        {
            List<int> ints = new List<int>()
            {
                1,2,3,4,5
            };

            List<int> ints1 = new List<int>();

            ints.ForEach(i => ints1.Add(i));

            ints1.ForEach(i => Console.WriteLine(i));
        }
    }
}
