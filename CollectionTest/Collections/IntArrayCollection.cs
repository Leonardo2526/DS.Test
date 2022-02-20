using System;
using System.Collections.Generic;

namespace CollectionTest
{
    public class IntArrayCollection : ICollectionCreator
    {

        public List<int> GetValues()
        {
            int count = 100000;
            int[] numbersArray = new int[count];
            for (int i = 0; i < count; i++)
            {
                numbersArray[i] = i;
            }

            //Print.PrintIndexAndValues(numbersArray);

            List<int> outlist = new List<int>();

            for (int i = 5; i < 200000; i++)
            {
                int c = Array.BinarySearch(numbersArray, i);
                //int c = Array.IndexOf(numbersArray, i);
                if (c > 0)
                    outlist.Add(c);
            }

            return outlist;
        }
    }
}
