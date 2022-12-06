using Autofac;
using CollectionTest.CastTest;
using CollectionTest.Generics;
using CollectionTest.Generics.Meta;
using CollectionTest.Generics1;
using CollectionTest.Generics2;
using System;
using System.Collections.Generic;

namespace CollectionTest
{
    public class Program
    {
        //public static List<int> Run()
        //{
        //    var container = ContainerConfig.Configure();

        //    using (var scope = container.BeginLifetimeScope())
        //    {
        //        var app = scope.Resolve<IApplication>();

        //        return app.Run();
        //    }
        //}

        static void Main(string[] args)
        {


            SortDictionaryTest.Run();

            //GenericClient2.Run();

            //    MetaDataRunner.DoSomeThing();

            //MetaDataCollection.DoSomeThing();

            //GenericClient.RunGeneric();

            //ClientCast.RunTest();

            //List<int> outlist = Run();

            //Console.WriteLine("Result list: ");
            //Print.PrintIndexAndValues(outlist);


            //Console.WriteLine("\nList count: " + outlist.Count);
            Console.ReadLine();
        }
    }
}
