using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTest.SingletonLifetime
{
    static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            // A singleton declared at container build
            // time will be owned by the root scope and get
            // all dependencies from the root scope.
            builder.RegisterType<Component>()
                   .SingleInstance();

            // Anything that resolves a Dependency from
            // the root lifetime scope will see the name
            // as 'root'
            builder.Register(ctx => new Dependency("root"));

            return builder.Build();
        }
    }
}
