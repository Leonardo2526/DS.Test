using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest
{
    class ListCollectionCreator : ICollectionCreator
    {
        public void Create()
        {
            List<int> list = new List<int>()
            { 2,4,6,8};

            for (int i = 0; i < 1000; i++)
            {
                int c = list.BinarySearch(i);
                if (c > 0)
                    Console.WriteLine(c);
            }
        }
    }
}
