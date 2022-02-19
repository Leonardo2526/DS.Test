using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest
{
    static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>();

            //builder.RegisterType<IntListCollection>().As<ICollectionCreator>();
            builder.RegisterType<StringNuberListCollection>().As<ICollectionCreator>();
            //builder.RegisterType<StringListCollection>().As<ICollectionCreator>();

            return builder.Build();
        }
    }
}
