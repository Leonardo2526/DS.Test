using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics
{
    internal abstract class AbstractClass<T>
    {
        public abstract T Name { get; set; }
    }
}
