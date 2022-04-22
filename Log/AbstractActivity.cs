using System.Diagnostics;

namespace Tracing
{
    abstract class AbstractActivity
    {
        public AbstractActivity(string traceSourceName)
        {
            TS = new TraceSource(traceSourceName);
        }

        public TraceSource TS { get; protected set; }

        public abstract AbstractActivity Create();
      
    }
}
