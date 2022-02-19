using System.Collections.Generic;

namespace CollectionTest
{
    class IntListCollection : ICollectionCreator
    {

        public List<int> GetValues()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(i);
            }

        List<int> outlist = new List<int>();

            for (int i = 10; i < 2000000; i++)
            {
                int c = list.BinarySearch(i);
                if (c > 0)
                    outlist.Add(c);
            }

            return outlist;
        }
    }
}
