using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics
{
    //internal class ConcreteClass2 : AbstractClass
    //{
    //    public override string Name { get; set; }
    //    public override dynamic Age { get; set; }
    //}

    internal class ConcreteClass2 : AbstractClass, IProperty<byte>
    {
        public override string Name { get; set; }
        public byte Age { get; set; }
    }


    //internal class ConcreteClass2 : AbstractClass<string>
    //{
    //    public override string Name { get; set; }
    //}
}
