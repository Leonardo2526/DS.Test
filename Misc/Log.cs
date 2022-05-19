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

            ResumePathBuilder = new DirPathBuilder(_ResumeLogName, "");
            ResumeLogBuilder = new LogBuilder(ResumePathBuilder, SourceLevels.All);
        }

        public static LogBuilder ErrorLogBuilder { get; private set; }
        public static LogBuilder WarningLogBuilder { get; private set; }
        public static LogBuilder InfoLogBuilder { get; private set; }
        public static LogBuilder ResumeLogBuilder { get; private set; }

        public static DirPathBuilder ErrorPathBuilder { get; private set; }
        public static DirPathBuilder WarningPathBuilder { get; private set; }
        public static DirPathBuilder InfoPathBuilder { get; private set; }
        public static DirPathBuilder ResumePathBuilder { get; private set; }


        private static string _ErrorsLogName = "MEPAC_Errors";
        private static string _WarningsLogName = "MEPAC_Warnings";
        private static string _InfoLogName = "MEPAC_Info";
        private static string _ResumeLogName = "MEPAC_Resume";

        public static void AddMessageToAllBuilders(string message, TraceEventType traceEventType)
        {
            ErrorLogBuilder.AddMessage(message, traceEventType);
            WarningLogBuilder.AddMessage(message, traceEventType);
            InfoLogBuilder.AddMessage(message, traceEventType);
        }

        public void Create(MessageModel messageModel)
        {
            CreateOrdinary(messageModel);
            CreateResume(messageModel);
        }


        private void CreateOrdinary(MessageModel messageModel)
        {
            foreach (MessageCreator messageCreator in messageModel.MessageCreators)
            {
                if (messageCreator.EventType == TraceEventType.Resume)
                {
                    continue;
                }

                    MessageStringCreator messageStringCreator = new MessageStringCreator(messageCreator);

                string messages = "\n\n";
                foreach (var message in messageCreator.Messages)
                {
                    messages += messageStringCreator.Create(message, message.Collision);
                }

                string account = messageStringCreator.CreateAccount();

                LogBuilder logBuilder = GetBuilder(messageCreator);
                logBuilder.AddMessage(messages + account, messageCreator.EventType);
            }
        }


        private void CreateResume(MessageModel messageModel)
        {
            foreach (MessageCreator messageCreator in messageModel.MessageCreators)
            {
                if (messageCreator.EventType != TraceEventType.Resume)
                {
                    continue;
                }

                MessageStringCreator messageStringCreator = new MessageStringCreator(messageCreator);

                string messages = "\n\n";
                foreach (var message in messageCreator.Messages)
                {
                    messages += messageStringCreator.CreateResume(message, message.Collision);
                }

                string account = messageStringCreator.CreateResumeAccount(messageModel.MessageCreators);

                LogBuilder logBuilder = GetBuilder(messageCreator);
                logBuilder.AddMessage(messages + account, messageCreator.EventType);
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
                    logBuilder = InfoLogBuilder;
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
                    logBuilder = ResumeLogBuilder;
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
