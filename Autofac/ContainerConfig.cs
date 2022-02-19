using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTest
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();

            builder.RegisterType<Print>().As<IPrint>();
            builder.RegisterType<Message>().As<IMessage>();
            builder.RegisterType<Calculation>().As<ICalculation>();

            return builder.Build();
        }
    }
}
