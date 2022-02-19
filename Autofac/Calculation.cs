using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTest
{
    public class Calculation : ICalculation
    {
        public void GetSum()
        {
            Console.WriteLine("2+2=4");
        }
    }
}
