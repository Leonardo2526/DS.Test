using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics
{
    internal abstract class AbstractClass
    {
        public abstract string Name { get; set; }
        public abstract dynamic Age { get; set; }
    }

    //internal abstract class AbstractClassTest : IName
    //{
    //    public abstract string Name { get; set; }
    //}

    //internal abstract class AbstractClass<T>
    //{
    //    public abstract T Name { get; set; }
    //}
}
