using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing
{
    class Activity1 : ActivityBuilder
    {
        public Activity1(string traceSourceName) : base(traceSourceName)
        { }

        public override ActivityBuilder Build()
        {
            TS.TraceEvent(TraceEventType.Error, 1,
               "Error message.");
            TS.TraceEvent(TraceEventType.Warning, 2,
                "Warning message.");

            return this;
        }
    }
}
