using System;
using System.Collections;

namespace CollectionTest
{
    class Print
    {
        public static void PrintIndexAndValues(IEnumerable list)
        {
            int i = 0;
            foreach (var item in list)
                Console.WriteLine($"   [{i++}]:  {item}");

            Console.WriteLine();
        }
    }
}
