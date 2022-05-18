using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    internal abstract class Message
    {
        public TraceEventType TraceEventType;
        public string Text;
        public string SubType;
        public int Id;

        public Message(string text, int id)
        {
            Text = text;
            Id = id;
        }
    }

  
}
