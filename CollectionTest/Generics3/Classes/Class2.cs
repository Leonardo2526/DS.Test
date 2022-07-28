using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics3
{
    //internal class Class2 : BaseClass
    //{
    //    public override string Name { get; set; }

    //}

    //internal class Class2<T> : BaseClass, IProperty<T>
    //{
    //    public override string Name { get; set; }

    //    T IProperty<T>.MyElement { get; set; }
    //}

    internal class Class2 : BaseClass<MEPCurve>, IProperty
    {
        public override string Name { get; set; }
        public string Name1 { get; set; }
    }
}

