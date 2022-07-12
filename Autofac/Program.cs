using Autofac;
using Autofac.SingletonLifetime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTest
{
    class Program 
    {
        static void Main(string[] args)
        {
            Scope.RunRoot();
            //Scope.Run1();

            Console.ReadLine();
        }

        static void Main0(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

            Console.ReadLine();
        }
    }
}
