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
            double A1 = 0;
            double A2 = -1.1;
            double A3 = 0.0001;
            Console.WriteLine(Math.Round(A2));

            double B1 = 0.01;
            
            Console.WriteLine(A1.CompareTo(B1));
            Console.WriteLine(A2.CompareTo(B1));
            Console.WriteLine(A3.CompareTo(B1));
            //Console.WriteLine(A1.CompareTo(B1.CompareTo((Object)B1)));



            Console.ReadLine();
        }
    }
}
