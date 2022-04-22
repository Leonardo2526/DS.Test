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
            //RunPersonBuilder();
            RunCollisionBuilder();

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

        private static void RunCollisionBuilder()
        {
            var collisionBuilder = new CollisionBuilder();

            Collision collision = collisionBuilder.GetCollisionModel()
                .NameOf("new collision model");
            collision = collisionBuilder.GetBypassModel().
                NameOf("new bypass model");

            Console.WriteLine(collision.CollisionModel.NameCollision);
            Console.WriteLine(collision.BypassModel.NameBypass);
        }


    }
}
