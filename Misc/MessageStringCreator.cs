using Misc.MessageTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    internal static class MessageStringCreator
    {
      public static string Create(Message message, Collision collision)
        {
            return $"{message.TraceEventType} {message.Id}: " +
                $"Collision {collision.Id} ({collision.MECCurve1Id}, {collision.MECCurve2Id}) - " +
                $"{message.SubType} warning. {message.Text}\n";
        }

        public static string ResumeWarnings(MessageCreator messageCreator)
        {

            string subTypes = null;

            foreach (KeyValuePair<SubType, int> item in messageCreator.SubTypes)
            {
                subTypes += "   " + item.Key + " - " + item.Value + "\n";
            }


            return $"\nWarning types count: \n" + subTypes;
        }
    }
}
