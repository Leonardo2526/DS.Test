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
           
            //ListOutput1();

            Console.ReadLine();
        }

        static void ListOutput1()
        {
            Test1.EqualLists();
            ListOutput();

            Console.WriteLine();

            Test1.ChangeList();
            ListOutput();

        }


        static void ListOutput()
        {
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
        }
    }
}
