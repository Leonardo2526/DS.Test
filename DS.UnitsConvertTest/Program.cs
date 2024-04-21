using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;
using UnitsNet.Units;

namespace DS.UnitsConvertTest
{
    internal class Program
    {
        static void Main(string[] args)
        {          
            var f1 = UnitConverter.Convert(1, LengthUnit.Foot, LengthUnit.Millimeter);
            Console.WriteLine(f1);

            var f1_2 = UnitConverter.Convert(1, AreaUnit.SquareFoot, AreaUnit.SquareMillimeter);
            Console.WriteLine(f1_2);


            var r1 = UnitConverter.Convert(1, AngleUnit.Degree, AngleUnit.Radian);
            Console.WriteLine(r1);

            Console.ReadLine();
        }
    }
}
