using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics
{
    internal static class GenericClient
    {
        public static void Run()
        {
            var cl1 = new ConcreteClass1();
            cl1.Age = (int)1;

            var cl2 = new ConcreteClass2();
            cl2.Age = (byte)2;

            List<AbstractClass> list = new List<AbstractClass>();
            list.Add(cl1);
            list.Add(cl2);


            foreach (var item in list)
            {
                Console.WriteLine(item.Age);
            }
        }
    }
}
