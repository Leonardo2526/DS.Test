using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleToIntTest
{
    class Program
    {
        static void Main(string[] args)
        {
            double b = 51 / 50;
            int a = (int)Math.Round(b);
            Console.WriteLine(a.ToString());
            Console.ReadLine();
        }
    }
}
