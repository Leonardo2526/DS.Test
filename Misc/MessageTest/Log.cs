using DS.MainUtils;
using DS.TraceUtils;
using Misc.MessageTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Misc
{ 
    public class Log
    {
        public Log()
        {
            ErrorPathBuilder = new DirPathBuilder(_ErrorsLogName, "Log");
            ErrorLogBuilder = new LogBuilder(ErrorPathBuilder, SourceLevels.Error);

            WarningPathBuilder = new DirPathBuilder(_WarningsLogName, "");
            WarningLogBuilder = new LogBuilder(WarningPathBuilder, SourceLevels.Warning);

            InfoPathBuilder = new DirPathBuilder(_InfoLogName, "");
            InfoLogBuilder = new LogBuilder(InfoPathBuilder, SourceLevels.Information);

            ResumePathBuilder = new DirPathBuilder(_ResumeLogName, "");
            ResumeLogBuilder = new LogBuilder(ResumePathBuilder, SourceLevels.All);

            _MessagesByEvTypes = SortByEventTypes();
        }

        private Dictionary<TraceEventType, List<Message>> _MessagesByEvTypes;

        public static LogBuilder ErrorLogBuilder { get; private set; }
        public static LogBuilder WarningLogBuilder { get; private set; }
        public static LogBuilder InfoLogBuilder { get; private set; }
        public static LogBuilder ResumeLogBuilder { get; private set; }

        public static DirPathBuilder ErrorPathBuilder { get; private set; }
        public static DirPathBuilder WarningPathBuilder { get; private set; }
        public static DirPathBuilder InfoPathBuilder { get; private set; }
        public static DirPathBuilder ResumePathBuilder { get; private set; }


        private static string _ErrorsLogName = "MEPAC_Errors1";
        private static string _WarningsLogName = "MEPAC_Warnings";
        private static string _InfoLogName = "MEPAC_Info";
        private static string _ResumeLogName = "MEPAC_Resume";

        public static void AddMessageToAllBuilders(string message, TraceEventType traceEventType)
        {
            ErrorLogBuilder.AddMessage(message, traceEventType);
            WarningLogBuilder.AddMessage(message, traceEventType);
            InfoLogBuilder.AddMessage(message, traceEventType);
        }

        public void Create()
        {
            CreateOrdinary();
            CreateResume();
        }

        private Dictionary<TraceEventType, List<Message>> SortByEventTypes()
        {
            Dictionary<TraceEventType, List<Message>> messagesByEvTypes = new Dictionary<TraceEventType, List<Message>>();

            foreach (var message in MessageCreator.Messages)
            {
                TraceEventType evtype = message.TraceEventType;
                if (!messagesByEvTypes.Keys.Contains(evtype))
                {
                    messagesByEvTypes.Add(evtype, new List<Message>() { message });
                }
                else
                {
                    messagesByEvTypes[evtype].Add(message);
                }
            }

            return messagesByEvTypes;
        }

        private void CreateOrdinary()
        {
            foreach (var item in _MessagesByEvTypes)
            {
                if (item.Key == TraceEventType.Resume)
                {
                    continue;
                }
                var messageStringCreator = new MessageStringCreator(item);
                string messages = messageStringCreator.Create();
                string account = messageStringCreator.CreateAccount();

                LogBuilder logBuilder = GetBuilder(item.Key);
                logBuilder.AddMessage(messages + account, item.Key);
            }
        }


        private void CreateResume()
        {
            KeyValuePair<TraceEventType, List<Message>> resume =
                _MessagesByEvTypes.Where(p => p.Key == TraceEventType.Resume).ToList().First();


            var messageStringCreator = new MessageStringCreator(resume);
            string messages = messageStringCreator.CreateResume();
            string account = messageStringCreator.CreateResumeAccount(resume, _MessagesByEvTypes);

            LogBuilder logBuilder = ResumeLogBuilder;
            logBuilder.AddMessage(messages + account, resume.Key);
        }

        private LogBuilder GetBuilder(TraceEventType traceEventType)
        {
            LogBuilder logBuilder = null;

            switch (traceEventType)
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
