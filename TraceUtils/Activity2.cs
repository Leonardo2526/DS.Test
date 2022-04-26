using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing
{
    class Activity2 : ActivityBuilder
    {
        public Activity2(string traceSourceName, string message = "") : base(traceSourceName)
        {
            Message = message;
        }

        private string Message;

        public override ActivityBuilder Build()
        {
            TS.TraceEvent(TraceEventType.Error, 1, "Error message." + Message);
            TS.TraceEvent(TraceEventType.Warning, 2, "Warning message.");
            TS.TraceEvent(TraceEventType.Critical, 3, "Critical message.");
            TS.TraceEvent(TraceEventType.Information, 4, "Informational message.");

            return this;
        }
    }
}
