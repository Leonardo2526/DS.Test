using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ChildClass1 childClass = new ChildClass1(10 ,20);

            foreach (var item in childClass.ModelGroup)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
