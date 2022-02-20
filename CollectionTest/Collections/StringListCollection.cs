using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Collections
{
    class StringListCollection : ICollectionCreator
    {
        public class ReverserClass : IComparer
        {
            // Call CaseInsensitiveComparer.Compare with the parameters reversed.
            int IComparer.Compare(object x, object y)
            {
                return ((new CaseInsensitiveComparer()).Compare(y, x));
            }
        }

        public List<int> GetValues()
        {
            List<string> list = new List<string>()
            { "One", "Two" , "Three" ,"Four", "Five"};
            list.Sort();          

            Console.WriteLine("Initial sorted list: ");
            Print.PrintIndexAndValues(list);

            List<int> outlist = new List<int>();

            int c;
            c = list.BinarySearch("Two");
                if (c > 0)
                    outlist.Add(c);

            c = list.BinarySearch("Five");
            if (c >= 0)
                outlist.Add(c);

            return outlist;
        }
    }
}
