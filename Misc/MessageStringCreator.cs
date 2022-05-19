using Misc.MessageTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    internal class MessageStringCreator
    {
        private MessageCreator _MessageCreator;
        public MessageStringCreator(MessageCreator messageCreator)
        {
            this._MessageCreator = messageCreator;
        }

      public string Create(Message message, Collision collision)
        {
            return $"{_MessageCreator.EventType} {message.Id}: " +
                $"Collision {collision.Id} ({collision.MECCurve1Id}, {collision.MECCurve2Id}) - " +
                $"{message.SubType} {_MessageCreator.EventType}. {message.Text}\n";
        }

        public string Resume()
        {

            string subTypes = null;

            foreach (KeyValuePair<SubType, int> item in _MessageCreator.SubTypesCounter)
            {
                subTypes += "   " + item.Key + " - " + item.Value + "\n";
            }


            return $"\n{_MessageCreator.EventType} types count: \n" + subTypes;
        }
    }
}
