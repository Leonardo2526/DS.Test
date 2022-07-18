using System;
using System.Collections.Generic;

namespace CollectionTest.Generics.Meta
{
    //use interfaces instead of abstract class
    public interface IMetadata
    {
        object MyProp { get; set; }
    }

    public interface IMetadata<T>
    {
        T MyProp { get; set; }
    }

    //as List<> the List and List<> don't derive from each other but instead have a common interface the non-generic IList
    public abstract class AbstractMetadata : IMetadata
    {
        public object MyProp { get; set; }
        public string MyProp2 { get; set; } = "prop";
    }

    //implement the generic and non-generic interface
    public class Metadata<T> : AbstractMetadata, IMetadata<T>, IMetadata
    {
        //hide the non-generic interface member MyCollection
        object IMetadata.MyProp
        {
            get { return (object)MyProp; }
            set { this.MyProp = (T)value; }
        }

        T IMetadata<T>.MyProp { get; set; }
    }

    public static class MetaDataRunner
    {
        public static void DoSomeThing()
        {
            //make a list of IMetadata
            List<AbstractMetadata> metadataObjects = new List<AbstractMetadata>
        {
            new Metadata<int>() { MyProp = 1, MyProp2 = "int" },
            new Metadata<bool>() { MyProp = false, MyProp2 = "bool" },
            new Metadata<double>() { MyProp = 1.01234, MyProp2 = "double" },
        };

            foreach (var item in metadataObjects)
            {               
                Console.WriteLine(item.MyProp.ToString() + " - " + item.MyProp2.ToString());
            }
        }
    }

}
