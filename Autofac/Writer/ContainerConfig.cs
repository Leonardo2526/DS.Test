using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.AutofacTest.Writer
{
    static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var Container = new ContainerBuilder();

            Container.RegisterType<ConsoleOutput>().As<IOutput>();
            Container.RegisterType<TodayWriter>().As<IDateWriter>();

            return Container.Build();
        }
    }
}
