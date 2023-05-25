using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MathTest
{
    class Program
    {
        TestClass _test = new TestClass();

        static void Main(string[] args)
        {
            var t = new TestClass1();
            t.Run2();

          
            //ConverationToSByteTest();
            //ConverationToIntTest();

            //Console.WriteLine(CompareTest());
            Console.ReadLine();
        }


        static void test1()
        {
            double a = 2.31480572365012;
            double b = 2.3142359862349058;

            double difference = Math.Abs(a * .001);

            if (Math.Abs(a - b) <= difference)
                Console.WriteLine("'a' and 'b' are equal.");
            else
                Console.WriteLine("'a' and 'b' are unequal.");
        }

        static int CompareTest()
        {
            int c = 3;
            double d = 2;

                return d.CompareTo(c);
           
        }

        static void ConverationToSByteTest()
        {
            sbyte a = 1;
            double b = Math.PI;
            Console.WriteLine("a=" + a);
            Console.WriteLine("b=" + b);
            Console.WriteLine("Converted b= " + Convert.ToSByte(b));
        }

        static void ConverationToIntTest()
        {
            int a = 1;
            double b = Math.PI;
            Console.WriteLine("a=" + a);
            Console.WriteLine("b=" + b);
            Console.WriteLine("Converted b= " + Convert.ToSByte(b));
        }
    }





    class TestClass
    {
        public TestClass()
        {
            Console.WriteLine("TestClass ctor called!");
        }
    }

    class TestClass1
    {
        //TestClass _test = new TestClass();
        TestClass _testProp => new TestClass();

        public void Run()
        {
            //Console.WriteLine(_test.ToString());
            //Console.WriteLine(_test.ToString());
            //Console.WriteLine(_test.ToString());
        }

        public void Run2()
        {
            var p= _testProp;
            p = _testProp;
            p = _testProp;
        }
    }
}
