using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    public class MessageModel
    {
        public List<MessageCreator> MessageCreators { get; private set; } = new List<MessageCreator>();

        public void AddMessage(string textMessage, TraceEventType traceEventType, SubType subType, ClsnInfo collision)
        {
            MessageCreator messageCreator = GetCreator(traceEventType);
            MessageCreator containsMessageCreator = IsCreatorsContainsCreator(messageCreator);

            if (containsMessageCreator is null)
            {
                MessageCreators.Add(messageCreator);
                messageCreator.CreateMessage(textMessage, subType, collision);
            }
            else
            {
                containsMessageCreator.CreateMessage(textMessage, subType, collision);
            }
        }

        public void AddResumeMessage(string textMessage, ClsnInfo collision)
        {
            ResumeMessageCreator messageCreator = new ResumeMessageCreator();
            ResumeMessageCreator containsMessageCreator = (ResumeMessageCreator)IsCreatorsContainsCreator(messageCreator);

            if (containsMessageCreator is null)
            {
                MessageCreators.Add(messageCreator);
                messageCreator.CreateResumeMessage(textMessage, collision);
            }
            else
            {
                containsMessageCreator.CreateResumeMessage(textMessage, collision);
            }
        }

        private MessageCreator GetCreator(TraceEventType traceEventType)
        {
            MessageCreator messageCreator = null;

            switch (traceEventType)
            {
                case TraceEventType.Critical:
                    break;
                case TraceEventType.Error:
                    messageCreator = new ErrorMessageCreator();
                    break;
                case TraceEventType.Warning:
                    messageCreator = new WarningMessageCreator();
                    break;
                case TraceEventType.Information:
                    messageCreator = new InfoMessageCreator();
                    break;
                case TraceEventType.Verbose:
                    break;
                case TraceEventType.Start:
                    break;
                case TraceEventType.Stop:
                    break;
                case TraceEventType.Suspend:
                    break;
                case TraceEventType.Resume:
                    break;
                case TraceEventType.Transfer:
                    break;
                default:
                    break;
            }

            return messageCreator;
        }

        private MessageCreator IsCreatorsContainsCreator(MessageCreator messageCreator)
        {
            foreach (var item in MessageCreators)
            {
                if(item.GetType().ToString() == messageCreator.GetType().ToString())
                {
                    return item;
                }
            }

            return null;
        }
    }
}
