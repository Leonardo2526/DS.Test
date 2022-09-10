using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics2
{
    internal abstract class AbstractClass<T> : IClass
    {
        public abstract string Name { get; set; }
        public T Age { get; set; }
    }
}
