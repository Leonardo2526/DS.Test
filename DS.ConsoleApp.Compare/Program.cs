using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.Compare
{
    class Program
    {
        static void Main(string[] args)
        {
            double A1 = 10;
            double A2 = -10;
            double A3 = 2;


            double B1 = 2;
            ;
            Console.WriteLine(A1.CompareTo(B1));
            Console.WriteLine(A2.CompareTo(B1));
            Console.WriteLine(A3.CompareTo(B1));
            Console.WriteLine(A1.CompareTo(B1.CompareTo((Object)B1)));



            Console.ReadLine();
        }
    }
}
