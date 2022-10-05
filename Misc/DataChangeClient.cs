using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    internal static class DataChangeTest
    {
        public static void Run()
        {

            List<int> list = new List<int>() { 1, 2, 3 };
            var slist = new List<string>() { "a", "b", "c" };
            //var t = new Test<string>(slist);
            //t.ResetList();
            //var c = slist.Count();
            var d = new Data();
            Console.WriteLine(d.MyProperty);


            var t = new Test(d);
            t.Reset();

            Console.WriteLine(d.MyProperty);
        }
    }


    class Test<T>
    {
        private List<T> list;

        public Test(List<T> list)
        {
            list = null;
            this.list = list;
        }

        public void ResetList()
        {
            list = null;
        }
    }

    class Test
    {
        private Data _data;

        public Test(Data s)
        {
            _data = s;
        }

        public void Reset()
        {
            _data.MyProperty = 2;
        }
    }

    class Data
    {
        public int MyProperty { get; set; } = 1;
    }
}
