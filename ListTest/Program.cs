using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1.EqualLists();

            Console.WriteLine("List1");
            foreach (var item in Test1.List1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nList2");

            foreach (var item in Test1.List2)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
