using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTest
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine(CompareTest());
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
    }
}
