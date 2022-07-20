using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics1
{
    //internal abstract class BaseClass : IProperty
    //{
    //    public abstract string Name { get; set; }
    //    public BaseElement MyElement { get; set; }

    //    protected int MyProperty { get; set; }
    //}

    //internal abstract class BaseClass<T> : IProperty<T> where T : BaseElement
    //{
    //    public abstract string Name { get; set; }
    //    public T MyElement { get; set; }

    //}

    internal abstract class BaseClass
    {
        public string Name { get; set; }
        public BaseElement MyElement { get; set; }
    }
}
