using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    internal class WarningMessage : Message
    {
        public WarningMessage(SubType subType, string text, int id) : 
            base(text, id)
        {
            SubType = subType;
            TraceEventType = TraceEventType.Warning;
        }

    }
}
