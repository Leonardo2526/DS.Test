using AutofacTest.SingletonLifetime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.SingletonLifetime
{
    internal class Scope
    {
        public static IContainer container = ContainerConfig.Configure();

        public static void RunRoot()
        {
                // Resolve the component from the root lifetime scope.
                var rootComp = container.Resolve<Component>();

                // This will show "root"
                Console.WriteLine(rootComp.Name);          
        }

        public static void Run1()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                // Resolve the component from the root lifetime scope.
                var rootComp = container.Resolve<Component>();

                // This will show "root"
                Console.WriteLine(rootComp.Name);
            }
        }
    }
}
