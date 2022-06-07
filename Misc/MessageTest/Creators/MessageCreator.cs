using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    public static class MessageCreator
    {
   
        public static List<Message> Messages { get; private set; } = new List<Message>();
        public static List<ClsnInfo> Collisions { get; private set; } = new List<ClsnInfo>();


        //Factory method
        public static Message CreateMessage(string text, TraceEventType traceEventType, SubType subType, ClsnInfo clsnInfo)
        {
            Message message = new Message(text, traceEventType, clsnInfo, subType);
            Messages.Add(message);

            return message;
        }

        //Factory method
        public static Message CreateResumeMessage(string text, ClsnInfo clsnInfo)
        {
            Collisions.Add(clsnInfo);
            Message message = new Message(text, TraceEventType.Resume, clsnInfo);
            Messages.Add(message);

            return message;
        }
    }
}
