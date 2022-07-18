using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics
{
    internal interface IProperty<T>
    {
        public T Age { get; set; }
    }
}
