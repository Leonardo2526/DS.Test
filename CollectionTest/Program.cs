using Autofac;
using System;
using System.Collections.Generic;

namespace CollectionTest
{
    public class Program
    {
        public static List<int> Run()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                return app.Run();
            }

        }

        static void Main(string[] args)
        {
            List<int> outlist = Run();

            //Console.WriteLine("List: ");
            //Print.PrintIndexAndValues(outlist);


            Console.WriteLine("\nList count: " + outlist.Count);
            Console.ReadLine();
        }
    }
}
