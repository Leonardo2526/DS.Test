using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.AutofacTest.Writer
{
    internal class Scope
    {
        public static IContainer container = ContainerConfig.Configure1();
        //public static IContainer container = ContainerConfig.Configure();
        public static void WriteDate()
        {
            // Create the scope, resolve your IDateWriter,
            // use it, then dispose of the scope.
            using (var scope = container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate1();
            }
        }
    }
}
