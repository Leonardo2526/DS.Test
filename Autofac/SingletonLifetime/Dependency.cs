using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTest.SingletonLifetime
{
    internal class Dependency
    {
        public string Name { get; }

        public Dependency(string name)
        {
            this.Name = name;
        }
    }
}
