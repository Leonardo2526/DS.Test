using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics
{
    internal class ConcreteClass1 : AbstractClass<string>
    {
        public override string Name { get; set; }
    }
}
