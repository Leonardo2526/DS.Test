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
            var m1 = UnitConverter.Convert(1, LengthUnit.Millimeter, LengthUnit.Foot);
            Console.WriteLine(m1);

            var f1 = UnitConverter.Convert(0.001, LengthUnit.Foot, LengthUnit.Millimeter);
            Console.WriteLine(f1);

            var f1_2 = UnitConverter.Convert(1, AreaUnit.SquareFoot, AreaUnit.SquareMillimeter);
            Console.WriteLine(f1_2);

            var r1 = UnitConverter.Convert(1, AngleUnit.Degree, AngleUnit.Radian);
            Console.WriteLine(r1);


            Console.WriteLine(Length.FromMeters(1).Feet);
            Console.WriteLine(Area.FromSquareFeet(1).SquareMillimeters);
            Console.WriteLine(Volume.FromCubicFeet(1).CubicMillimeters);
            Console.WriteLine(Angle.FromRadians(1).Degrees);

            IQuantity quantity = Quantity.From(1, LengthUnit.Millimeter); // Length           
            var unitConverter = UnitConverter.Default;
            IQuantity ConvertMM(int n) => Quantity.From(n, LengthUnit.Millimeter);
            //var f = new ConversionFunction<IQuantity>(ConvertMM);
            //Length.DefaultConversionFunctions.SetConversionFunction(LengthUnit.Foot, LengthUnit.Millimeter, )
            //var u=  unitConverter.GetConversionFunction<>(LengthUnit.Millimeter, LengthUnit.Foot);
            //var from = new HowMuch(10, HowMuchUnit.Tons);
            //IQuantity Convert(int n) => unitConverter.GetConversionFunction<IQuantity>(LengthUnit.Millimeter, LengthUnit.Foot);

            var r = ConvertMM(1);
            r.As(LengthUnit.Foot);

            Console.ReadLine();
        }

        private static double MToFeet(QuantityValue quantityValue) => 
            Length.FromMeters(quantityValue).Feet;
    }

}
