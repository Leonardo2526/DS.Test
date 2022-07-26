using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics1
{
    internal abstract class BaseClass<T> : IProperty where T : BaseElement
    {
        public abstract string Name { get; set; }
        public T MyElement { get; set; }
    }
}
