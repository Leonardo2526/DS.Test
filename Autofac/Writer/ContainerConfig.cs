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
        public static IContainer container = ContainerConfig.Configure();
        public static IContainer Configure()
        {
            var Container = new ContainerBuilder();

            Container.RegisterType<ConsoleOutput1>().As<IOutput>();
            Container.RegisterType<TodayWriter1>().As<IDateWriter>();

            return Container.Build();
        }

        public static IContainer Configure1()
        {
            var Container = new ContainerBuilder();

            Container.RegisterType<TodayWriter1>().As<IDateWriter>();

            return Container.Build();
        }
    }
}
