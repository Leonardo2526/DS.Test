using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing
{
    class Activity1 : AbstractActivity
    {
        public Activity1(string traceSourceName) : base(traceSourceName)
        { }

        public override AbstractActivity Create()
        {
            TS.TraceEvent(TraceEventType.Error, 1,
               "Error message.");
            TS.TraceEvent(TraceEventType.Warning, 2,
                "Warning message.");

            return this;
        }
    }
}
