using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.CastTest
{
    internal class ClientCast
    {
        static List<AbstractClass>  abstractClasses = new List<AbstractClass>();

        public static void RunTest()
        {
            var concreteItem = new ConcreteClass();
            concreteItem.Prop = 0;
            abstractClasses.Add(concreteItem);
            ConcreteClass2 concreteItem2 = new ConcreteClass2();
            concreteItem2.Prop = 1;
            concreteItem2.Prop2 = 2;
            abstractClasses.Add(concreteItem2);

            ConcreteClass c1 = abstractClasses.First() as ConcreteClass;
          
            var concreteClasses = abstractClasses.OfType<ConcreteClass>().ToList();
            foreach (var item in concreteClasses)
            {
                Console.WriteLine(item.Prop);
            }
            var concreteClasses2 = abstractClasses.OfType<ConcreteClass2>().ToList();
            foreach (var item in concreteClasses2)
            {
                Console.WriteLine(item.Prop);
                Console.WriteLine(item.Prop2);
            }
        }
    }
}
