using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassTest
{
    internal abstract class ParentClass1<T>
    {
        public ParentClass1() { }

        public abstract List<T> ModelGroup { get; abstract set; }

        public abstract void CreateModel();
    }

   
}
