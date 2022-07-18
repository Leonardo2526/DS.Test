using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics
{
    internal interface IName<T>
    {
        public T Age { get; set; }
    }
}
