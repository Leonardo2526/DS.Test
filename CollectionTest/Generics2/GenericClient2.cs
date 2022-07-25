using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics2
{
    internal static class GenericClient2
    {
        public static void Run()
        {
            var cl1 = new ConcreteClass1<int>();
            cl1.Age = 1;
            //cl1.Age = (int)1;

            var cl2 = new ConcreteClass2<double>();
            cl2.Age = 2;
            //cl2.Age = (byte)2;

            var list = new List<IClass>();
            list.Add(cl1);
            list.Add(cl2);

            var classes1 = list.OfType< ConcreteClass1<int>> ();
            //var classes1 = list.Cast<ConcreteClass1<int>>().ToList();

            foreach (var item in classes1)
            {
                var itemProp = item;
                
                Console.WriteLine(itemProp.Age);
            }
        }
    }
}
