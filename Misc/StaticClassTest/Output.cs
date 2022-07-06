using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.StaticClassTest
{
    internal class Output
    {
        public static void Run()
        {
            Class1 class1 = new Class1();
            class1.Run(1, "name1");

            Class1 class2 = new Class1();
            class2.Run(2, "name2");

            Console.WriteLine(class1.Id);
            Console.WriteLine(class2.Id);
            Console.WriteLine(StaticClass.Field1);

            Console.WriteLine();

            Console.WriteLine(class1.Name);
            Console.WriteLine(class2.Name);
            Console.WriteLine(StaticClass.Field2);


            //StaticClass.Field1 = 0;
            //StaticClass.Field2 = "null";

            Console.WriteLine();

            Console.WriteLine(class1.Id);
            Console.WriteLine(class2.Id);
            Console.WriteLine(class1.Name);
            Console.WriteLine(class2.Name);

            class1.OutputStaticData();
            class2.OutputStaticData();
        }
        public static async Task RunAsync()
        {
            Class1 class1 = new Class1();
            await  Task.Run(() => class1.Run(1, "name1"));

            Class1 class2 = new Class1();
            await Task.Run(() => class2.Run(2, "name2"));

            Console.WriteLine(class1.Id);
            Console.WriteLine(class2.Id);
            Console.WriteLine(StaticClass.Field1);

            Console.WriteLine();

            Console.WriteLine(class1.Name);
            Console.WriteLine(class2.Name);
            Console.WriteLine(StaticClass.Field2);


            //StaticClass.Field1 = 0;
            //StaticClass.Field2 = "null";

            Console.WriteLine();

            Console.WriteLine($"class1.Id - {class1.Id}");
            Console.WriteLine($"class2.Id - {class2.Id}");
            Console.WriteLine($"class1.Name - {class1.Name}");
            Console.WriteLine($"class2.Name - {class2.Name}");

            var t3 = Task.Run(() => class1.OutputStaticData());
            var t4 = Task.Run(() => class2.OutputStaticData());

            Task.WaitAll();
        }
    }
}
