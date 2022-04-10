using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderFacets;
using StepwiseBuilder;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunCarBuilder();
            RunPersonBuilder();
         

            Console.ReadLine();
        }

        private static void RunPersonBuilder()
        {
            var pb = new PersonBuilder();
            Person person = pb
              .Lives
                .At("123 London Road")
                .In("London")
                .WithPostcode("SW12BC")
              .Works
                .At("Fabrikam")
                .AsA("Engineer")
                .Earning(123000);

            Console.WriteLine(person);
        }

        private static void RunCarBuilder()
        {
            var car = CarBuilder.Create()
           .OfType(CarType.Crossover)
           .WithWheels(18)
           .Build();
            Console.WriteLine(car.Type);
            Console.WriteLine(car.WheelSize);
        }


    }
}
