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
            for (int i = 3; i < 1000000; i++)
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
    }
}
