using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    using DS.MainUtils;
    using DS.TraceUtils;
    using Misc.MessageTest;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Log
    {
        public Log()
        {
            ErrorPathBuilder = new DirPathBuilder(_ErrorsLogName, "");
            ErrorLogBuilder = new LogBuilder(ErrorPathBuilder, SourceLevels.Error);

            WarningPathBuilder = new DirPathBuilder(_WarningsLogName, "");
            WarningLogBuilder = new LogBuilder(WarningPathBuilder, SourceLevels.Warning);

            InfoPathBuilder = new DirPathBuilder(_InfoLogName, "");
            InfoLogBuilder = new LogBuilder(InfoPathBuilder, SourceLevels.Information);
        }

        public static LogBuilder ErrorLogBuilder { get; private set; }
        public static LogBuilder WarningLogBuilder { get; private set; }
        public static LogBuilder InfoLogBuilder { get; private set; }

        public static DirPathBuilder ErrorPathBuilder { get; private set; }
        public static DirPathBuilder WarningPathBuilder { get; private set; }
        public static DirPathBuilder InfoPathBuilder { get; private set; }


        private static string _ErrorsLogName = "MEPAC_Errors";
        private static string _WarningsLogName = "MEPAC_Warnings";
        private static string _InfoLogName = "MEPAC_Info";

        public static void AddMessageToAllBuilders(string message, TraceEventType traceEventType)
        {
            ErrorLogBuilder.AddMessage(message, traceEventType);
            WarningLogBuilder.AddMessage(message, traceEventType);
            InfoLogBuilder.AddMessage(message, traceEventType);
        }

        public void Create(MessageModel messageModel)
        {

            foreach (MessageCreator messageCreator in messageModel.MessageCreators)
            {
                MessageStringCreator messageStringCreator = new MessageStringCreator(messageCreator);

                string messages = null;
                foreach (var message in messageCreator.Messages)
                {
                    messages += messageStringCreator.Create(message, message.Collision);
                }

                LogBuilder logBuilder = GetBuilder(messageCreator);

                logBuilder.AddMessage(messages, messageCreator.EventType);
                logBuilder.AddMessage(messageStringCreator.Resume());
            }
        }

        private LogBuilder GetBuilder(MessageCreator messageCreator)
        {
            LogBuilder logBuilder = null;

            switch (messageCreator.EventType)
            {
                case TraceEventType.Critical:
                    break;
                case TraceEventType.Error:
                    logBuilder = ErrorLogBuilder;
                    break;
                case TraceEventType.Warning:
                    logBuilder = WarningLogBuilder;
                    break;
                case TraceEventType.Information:
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

            return logBuilder;
        }

    }

}
