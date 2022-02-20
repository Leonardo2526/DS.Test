using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Collections
{
    class ListRemover : ICollectionCreator
    {
    
        public List<int> GetValues()
        {
            List<int> list = new List<int>();
            for (int i = 3; i < 10000; i++)
            {
                list.Add(i);
            }

            //Console.WriteLine("Initial queue: ");
            //Print.PrintIndexAndValues(list);

            int cnt = list.Count;
            for (int i = 0; i < cnt - 1; i++)
            {
                list.RemoveAt(0);
            }

            return list;
        }

        public List<int> GetValues0()
        {
            int cnt = 100000;

            List<int> list = new List<int>();
            for (int i = 3; i < cnt; i++)
            {
                list.Add(i);
            }

            //Console.WriteLine("Initial queue: ");
            //Print.PrintIndexAndValues(list);

            for (int i = 0; i < cnt - 1; i++)
            {
                int index = list.BinarySearch(i);
                if (index >= 0)
                    list.RemoveAt(index);
            }

            return list;
        }

    }
}
