using System.Collections.Generic;

namespace CollectionTest
{
    public class IntListCollection : ICollectionCreator
    {

        public List<int> GetValues()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 100000; i++)
            {
                list.Add(i);
            }

        List<int> outlist = new List<int>();

            for (int i = 5; i < 200000; i++)
            {
                int c = list.BinarySearch(i);
                //int c = list.IndexOf(i);
                if (c > 0)
                    outlist.Add(c);
            }

            return outlist;
        }
    }
}
