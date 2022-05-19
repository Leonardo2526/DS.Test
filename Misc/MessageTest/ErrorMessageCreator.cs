using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    internal class ErrorMessageCreator : MessageCreator
    {
        public override TraceEventType EventType { get; set; } = TraceEventType.Error;

    }
}
