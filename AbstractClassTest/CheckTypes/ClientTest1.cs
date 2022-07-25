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
            BaseClass class1 = new ConcreteClass1() { Name = "MyName"};
            var class2 = new ConcreteClass2();

            Test(class1);

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

        private static void Test(BaseClass baseClass)
        {
            var cl = baseClass as ConcreteClass1;
        }
    }
}
