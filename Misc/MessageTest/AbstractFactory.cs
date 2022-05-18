using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    internal abstract class AbstractFactory
    {
        public abstract Message CreateMessage(string text);
    }
}
