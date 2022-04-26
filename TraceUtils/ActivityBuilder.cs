using System.Diagnostics;

namespace Tracing
{
    abstract class ActivityBuilder
    {
        public ActivityBuilder(string traceSourceName)
        {
            TS = new TraceSource(traceSourceName);
        }

        public TraceSource TS { get; protected set; }

        public abstract ActivityBuilder Build();
      
    }
}
