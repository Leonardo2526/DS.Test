using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    public class Message
    {
        public string Text { get; }
        public TraceEventType TraceEventType { get; }
        public ClsnInfo ClsnInfo { get; }
        public SubType SubType { get; }

        public Message(string text, TraceEventType traceEventType, ClsnInfo collision, SubType subType)
        {
            Text = text;
            SubType = subType;
            ClsnInfo = collision;
            TraceEventType = traceEventType;
        }

        public Message(string text, TraceEventType traceEventType, ClsnInfo collision)
        {
            Text = text;
            ClsnInfo = collision;
            TraceEventType = traceEventType;
        }
    }

  
}
