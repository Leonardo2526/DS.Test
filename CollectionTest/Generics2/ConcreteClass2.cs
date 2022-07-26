using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics2
{
    internal class ConcreteClass2 : AbstractClass<double>, IClass
    {
        public override string Name { get; set; }
    }
}
