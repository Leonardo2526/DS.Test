using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Collections
{
    class StringNuberListCollection : ICollectionCreator
    {
        public List<int> GetValues()
        {
            List<string> list = new List<string>();
            for (int j = 0; j < 1000000; j++)
            {
                list.Add($"{j}");
            }

            List<int> outlist = new List<int>();
            for (int i = 0; i < 2000000; i++)
            {
                int c = list.BinarySearch($"{i}");
                //int c = list.IndexOf($"{i}");
                if (c > 0)
                    outlist.Add(c);
            }

            return outlist;
        }
    }
}
