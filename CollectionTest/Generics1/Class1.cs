using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics1
{
    //internal class Class1: BaseClass
    //{
    //    public override string Name { get; set; }

    //    public Class1()
    //    {

    //    }
    //}

    //internal class Class1 : BaseClass, IProperty
    //{
    //    public override string Name { get; set; }
    //    BaseElement IProperty.MyElement { get; set; }
    //}

    internal class Class1 : BaseClass<Element>, IProperty
    {
        public override string Name { get; set; }
        
    }

}
