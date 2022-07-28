using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics3
{
    internal static class ClientGeneric3
    {    
        public static void Run()
        {
            //var baseList = new List<IProperty>();
            var list = new List<IProperty>();


            var element1 = new Element() { Name = "element", ElementId = 1 };
            var class1 = new Class1() { Name = "class1", MyElement = element1 };

            var element2 = new MEPCurve() { Name = "mepCurve" , MEPId = 2};
            var class2 = new Class2() { Name = "class2", MyElement = element2 };

            list.Add(class1);
            list.Add(class2);

            //var baseTypes = list.Cast<BaseClass<BaseElement>>().ToList();
            //List<BaseClass<BaseElement>> baseTypes = list.OfType<BaseClass<BaseElement>>().ToList();
            //foreach (var item in baseTypes)
            //{
            //    Console.WriteLine(item.Name + " - " + item.MyElement.Name);
            //}
            PrintAllFields(list);
            //foreach (var item in list)
            //{
            //    var baseItem = (BaseClass<BaseElement>)item;
            //    Console.WriteLine(baseItem.Name + " - " + baseItem.MyElement.Name);
            //}


            Console.WriteLine("\n class1 types:");
            var class1Types = list.OfType<Class1>();
            foreach (var item in class1Types)
            {
                var prop1 = item.MyElement.Name;
                var prop2 = item.MyElement.ElementId;
                Console.WriteLine(item.Name + " - " + prop1 + " - " + prop2);
            }

            Console.WriteLine("\n class2 types:");
            var class2Types = list.OfType<Class2>();
            foreach (var item in class2Types)
            {
                var prop1 = item.MyElement.Name;
                var prop2 = item.MyElement.MEPId;
                Console.WriteLine(item.Name + " - " + prop1 + " - " + prop2);
            }
        }

        private static void PrintAllFields(List<IProperty> list)
        {
            List<BaseElement> baseElements = new List<BaseElement>();

            baseElements.AddRange(list.OfType<Class1>().Select(x => x.MyElement).ToList());
            baseElements.AddRange(list.OfType<Class2>().Select(x => x.MyElement).ToList());            

            foreach (var item in baseElements)
            {
                Console.WriteLine(item.Name);
            }
        }


        private static List<BaseElement> GetElements(IEnumerable<BaseClass<BaseElement>> list)
        {
            List<BaseElement> baseElements = new List<BaseElement>();

            foreach (var item in list)
            {
                baseElements.Add(item.MyElement);
            }

            return baseElements;
        }

        //private static void PrintAllFields(List<IProperty> list)
        //{
        //Type type = typeof(BaseClass<BaseElement>);
        //ReflectiveEnumerator.GetEnumerableOfType<Type>();

        ////Type type = list.First().GetType();
        //var types = type.GEt
        ////var types = type.GetNestedTypes();
        //foreach (var item in types)
        //{
        //    Console.WriteLine(item.Name);
        //}
        //}

    }
}
