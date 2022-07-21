using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassTest.CheckTypes
{
    internal static class ClientTest1
    {
        public static void Run()
        {
            List<BaseClass> baseClasses = new List<BaseClass>();
            var class1 = new ConcreteClass1();
            var class2 = new ConcreteClass2();

            baseClasses.Add(class1);
            baseClasses.Add(class2);

            var class2Type = typeof(ConcreteClass2);

            foreach (var item in baseClasses)
            {
                Type type = item.GetType();
                if (type.Name == class2Type.Name)
                {
                    Console.WriteLine(type.Name);
                }
                Console.WriteLine(item.GetType());
            }
        }
    }
}
