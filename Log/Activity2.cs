using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing
{
    class Activity2 : AbstractActivity
    {
        public Activity2(string traceSourceName) : base(traceSourceName)
        { }

        public override AbstractActivity Create()
        {
            TS.TraceEvent(TraceEventType.Error, 1, "Error message.");
            TS.TraceEvent(TraceEventType.Warning, 2, "Warning message.");
            TS.TraceEvent(TraceEventType.Critical, 3, "Critical message.");
            TS.TraceInformation("Informational message.");

            return this;
        }
    }
}
