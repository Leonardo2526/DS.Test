using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTest
{
    static class Test1
    {
        public static List<int> List1 { get; private set; } = new List<int>()
            {
                1,2,3
            };

        public static List<int> List2 { get; } = new List<int>()
            {
                4,5
            };


        public static void EqualLists()
        {
            List1 = List2;
        }


        public static void ChangeList()
        {
            List2.Add(0);
        }
    }
}
