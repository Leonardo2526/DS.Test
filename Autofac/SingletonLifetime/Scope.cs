using AutofacTest.SingletonLifetime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.SingletonLifetime
{
    internal class Scope
    {
        public static IContainer container = ContainerConfig.Configure();
        public static Component rootComp = container.Resolve<Component>();

        public static void RunRoot()
        {
            // Resolve the component from the root lifetime scope.
            Component rootComp = container.Resolve<Component>();

            // This will show "root"
            Console.WriteLine(rootComp.Name);
        }

        public static void RunChild1()
        {
            // Even if we override the Dependency in a child
            // scope, it'll still show "root"
            using (var child1 = container.BeginLifetimeScope(
                    b => b.Register(ctx => new Dependency("child1"))))
            {
                var child1Comp = child1.Resolve<Component>();
                Console.WriteLine(child1Comp.Name);
            }
        }

        public static void RunChild2()
        {
            // You can override the singleton by adding a new
            // singleton in a child scope. This one will be
            // owned by the child and will work in its children,
            // but it doesn't override at the root scope.
            using (var child2 = container.BeginLifetimeScope(
              b =>
              {
                  b.RegisterType<Component>().SingleInstance();
                  b.Register(ctx => new Dependency("child2"));
              }))
            {
                var child2Comp = child2.Resolve<Component>();

                // This will show "child2"
                Console.WriteLine(child2Comp.Name);

                // rootComp and child2Comp are TWO DIFFERENT SINGLETONS.
                //Debug.Assert(rootComp != child2Comp);
            }
        }
    }
}
