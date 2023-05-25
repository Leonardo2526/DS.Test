using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    internal class ListTest
    {
        public ListTest(List<int> myList)
        {
            MyList = myList;
            ListTest1 = new ListTest1(myList);
        }

        public List<int> MyList { get; set; }
        public ListTest1 ListTest1 { get; }
    }

    class ListTest1
    {
        public ListTest1(List<int> myList)
        {
            MyList = myList;
            ListTest11 = new ListTest11(myList);
        }

        public List<int> MyList { get; }
        public ListTest11 ListTest11 { get; }
    }

    class ListTest11
    {
        public ListTest11(List<int> myList)
        {
            MyList = myList;
        }

        public List<int> MyList { get; }
    }
}
