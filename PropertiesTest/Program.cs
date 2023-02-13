using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Class1 class1 = new Class1();
            //class1.MyProperty2 = 15;

            //Console.WriteLine(class1.MyProperty2);

            //Class2 class2 = new Class2();
            //class2.MyProperty = 1;

            var inst = new Class4();
            var i = inst.Prop1;
            i = inst.Prop1;
            i = inst.Prop1;
            i = inst.Prop3;
            i = inst.Prop3;
            i = inst.Prop4;
            i = inst.Prop4;
            i = Class4.Prop2;
            i = Class4.Prop2;

            inst = new Class4();
            i = inst.Prop1;

            //Console.WriteLine(class2.MyProperty);
            //Console.WriteLine(class2.MyProperty1);
            Console.ReadLine();
        }
    }
}
