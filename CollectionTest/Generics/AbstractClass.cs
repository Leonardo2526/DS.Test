using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics
{
    internal abstract class AbstractClass : IProperty
    {
        public abstract string Name { get; set; }
        public object Age { get; set; }
    }
}
