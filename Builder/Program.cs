using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StepwiseBuilder;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = CarBuilder.Create()
              .OfType(CarType.Crossover)
              .WithWheels(18)
              .Build();
            Console.WriteLine(car);

            Console.ReadLine();
        }
    }
}
