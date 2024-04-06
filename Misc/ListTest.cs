using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    internal static class ListTest
    {
        public static void Run()
        {
            var l1 = new ListTest1(); 
            l1.MyList = new List<int> { 1, 2 };

            var l2 = new ListTest1();
            l2.MyList = l1.MyList;

            l1.MyList.Add(3);
        }
    }

    class ListTest1
    {
        public List<int> MyList { get; set; }
    }

    class ListTest2
    { 
        public List<int> MyList { get; set; }
    }
}
