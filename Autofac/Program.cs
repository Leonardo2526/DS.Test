using Autofac;
using Autofac.SingletonLifetime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.ConsoleApp.AutofacTest.Writer;
using Scope = Autofac.SingletonLifetime.Scope;

namespace AutofacTest
{
    class Program 
    {
        static void Main(string[] args)
        {
            DS.ConsoleApp.AutofacTest.Writer.Scope.WriteDate();

            Console.ReadLine();
        }

        static void Main1(string[] args)
        {
            Scope.RunRoot();
            Scope.RunChild1();
            Scope.RunChild2();

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
