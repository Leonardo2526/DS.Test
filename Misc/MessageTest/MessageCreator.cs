using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    public abstract class MessageCreator
    {
        public MessageCreator()
        {
            foreach (var item in Enum.GetValues(typeof(SubType)))
            {               
                SubTypesCounter.Add((SubType)item, 0);
            }
        }


        public List<Message> Messages { get; set; } = new List<Message>();
        public Dictionary<SubType, int> SubTypesCounter { get; set; } = new Dictionary<SubType, int>();

        public abstract TraceEventType EventType { get; set; }

        //Factory method
        public Message CreateMessage(string text, SubType subType, ClsnInfo collision)
        {
            Message message = new Message(text, Messages.Count + 1, subType, collision);
            Messages.Add(message);

            foreach (KeyValuePair<SubType, int> item in SubTypesCounter)
            {
                var t = (SubType)item.Key;
                if (subType == t)
                {
                    SubTypesCounter[item.Key] = item.Value + 1;
                    break;
                }
            }

            return message;
        }
    }
}
