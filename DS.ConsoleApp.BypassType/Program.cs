using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.BypassType
{
    class Program
    {
        static void Main(string[] args)
        {
            new BypassPointModel(new Type1PointModelFactory(1,2));
            new BypassPointModel(new Type2PointModelFactory(2,2));

            Console.ReadLine();
        }
    }
}
