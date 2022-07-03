using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTest
{
    internal static class ListOrder
    {
        public static void OrderList()
        {
            List<int> ints = new List<int>()
            {
                5,2,7,1
            };

            ints =  ints.OrderBy(x => x).Reverse().ToList();

            foreach (var item in ints)
            {
                Console.WriteLine(item);
            }
        }
    }
}
