using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    internal class ResumeMessageCreator : MessageCreator
    {

        public List<ClsnInfo> Collisions { get; private set; } = new List<ClsnInfo>();

        public override TraceEventType EventType { get; set; } = TraceEventType.Resume;


        //Factory method
        public Message CreateResumeMessage(string text, ClsnInfo collision)
        {
            Collisions.Add(collision);
            Message message = new Message(text, Messages.Count + 1, collision);
            Messages.Add(message);

            return message;
        }
    }
}
