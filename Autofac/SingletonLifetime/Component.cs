using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTest.SingletonLifetime
{
    internal class Component
    {
        private readonly Dependency _dep;

        public string Name => this._dep.Name;

        public Component(Dependency dep)
        {
            this._dep = dep;
        }
    }
}
