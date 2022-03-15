using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassTest
{
    internal abstract class ParentClass<T>
    {
        public ParentClass() { }

        public abstract List<T> ModelGroup { get; set; }

        public abstract void CreateModel();
    }

   
}
