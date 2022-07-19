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
            cl1.Age = 1;
            //cl1.Age = (int)1;

            var cl2 = new ConcreteClass2();
            cl2.Age = 2;
            //cl2.Age = (byte)2;

            List<AbstractClass> list = new List<AbstractClass>();
            list.Add(cl1);
            list.Add(cl2);


            foreach (var item in list)
            {
                //var itemProp = (IProperty)item;
                
                //Console.WriteLine(itemProp.Age);
            }
        }

        public static void RunGeneric()
        {
            List<AbstractClass> list = new List<AbstractClass>();

            var gint = new GenericClass1<int>() { Name = "int", Age=1};
            list.Add(gint);
            gint = new GenericClass1<int>() { Name = "int", Age=2};
            list.Add(gint);

            var gbyte = new GenericClass1<double>() { Name = "double", Age = 3.123 };
            list.Add(gbyte);
            gbyte = new GenericClass1<double>() { Name = "double", Age = 4.123 };
            list.Add(gbyte);

            var gint2 = new GenericClass2<int>() { Name = "int", Age = 5, SecondName = "class2" };
            list.Add(gint2);
            gint2 = new GenericClass2<int>() { Name = "int", Age = 6, SecondName = "class2" };
            list.Add(gint2);


            var conrete= new ConreteClass() { Name = "int", Age = 7, SecondName = "conrete", ThirdName = "some" };
            list.Add(conrete);
            conrete = new ConreteClass() { Name = "int", Age = 8, SecondName = "conrete", ThirdName = "some" };
            list.Add(conrete);


            foreach (var item in list)
            {
                Console.WriteLine(item.Name + " - " + item.Age);
            }

            Console.WriteLine("\nInt types:");
            var intTypes = list.OfType<GenericClass1<int>>();
            foreach (var item in intTypes)
            {
                var age = (int)item.Age;
                Console.WriteLine(item.Name + " - " + age);
            }

            Console.WriteLine("\nDouble types:");
            var doubleTypes = list.OfType<GenericClass1<double>>();
            foreach (var item in doubleTypes)
            {
                var age = (double)item.Age;
                Console.WriteLine(item.Name + " - " + age);
            }

            Console.WriteLine("\nGenericClass2 types:");
            var class2 = list.OfType<GenericClass2<int>>();
            foreach (var item in class2)
            {
                var age = (int)item.Age;
                string sname = item.SecondName;
                Console.WriteLine(item.Name + " - " + age + " - " + sname);
            }

            Console.WriteLine("\nConcrete types:");
            var conreteClass = list.OfType<ConreteClass>();
            foreach (var item in conreteClass)
            {
                //var age = item.Age;
                var age = item.Age;
                string sname = item.SecondName;
                Console.WriteLine(item.Name + " - " + age + " - " + sname + " - " + item.ThirdName);
            }
        }
    }
}
