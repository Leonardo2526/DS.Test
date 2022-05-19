using Misc.MessageTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

      public string Create(Message message, ClsnInfo collision)
        {
            return $"{_MessageCreator.EventType} {message.Id}: " +
                $"Collision {collision.ClsnNumber} (Id1 = {collision.MECCurve1Id}, Id2 = {collision.MECCurve2Id}) - " +
                $"{message.SubType} {_MessageCreator.EventType.ToString().ToLower()}. {message.Text}\n";
        }

        public string CreateAccount(MessageCreator messageCreator)
        {
            string subTypes = "\n\n";
            int count = messageCreator.Messages.Count;
            subTypes += $"Total {messageCreator.EventType.ToString().ToLower()}s count: {count}\n";

            foreach (KeyValuePair<SubType, int> item in _MessageCreator.SubTypesCounter)
            {
                if (item.Value != 0)
                { 
                    subTypes += "   " + item.Key + " - " + item.Value + "\n";
                }

            }

            return subTypes;
        }


        public string CreateResume(Message message, ClsnInfo collision)
        {
            string isres = null;

            if (collision.IsResolved)
            {
                isres = "Resolved";
            }
            else
            {
                isres = "Unresolved";
            }

            return $"Collision {collision.ClsnNumber} (Id1 = {collision.MECCurve1Id}, Id2 =  {collision.MECCurve2Id}) " +
                $"- {isres} {message.Text}\n";
        }

        public string CreateResumeAccount(List<MessageCreator> messageCreators)
        {
            ResumeMessageCreator resumeMessageCreator = 
                (ResumeMessageCreator)messageCreators.Where(x => x.EventType == TraceEventType.Resume).First();

            string outString = "\n\n";
            outString += $"Total collisions count: {resumeMessageCreator.Collisions.Count}\n";

            int count = resumeMessageCreator.Collisions.Where(c => c.IsResolved == true).ToList().Count;
            outString += $"   Resolved collisions: {count}\n";

            count = resumeMessageCreator.Collisions.Where(c => c.IsResolved == false).ToList().Count;
            outString += $"   Unresolved collisions: {count}\n";

            outString += "\n\n";
            foreach (var messageCreator in messageCreators)
            {
                if (messageCreator.EventType == TraceEventType.Resume)
                {
                    continue;
                }

                count = messageCreator.Messages.Count;

                outString += $"Total {messageCreator.EventType.ToString().ToLower()}s count: {count}\n";
            }

            return outString;
        }
    }
}
