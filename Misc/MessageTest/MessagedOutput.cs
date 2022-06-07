using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    internal static class MessagedOutput
    {
        public static void Output()
        {
            ClsnInfo collision = new ClsnInfo(0, 11, 12);

            string textMessage;

            //Warning mes
            textMessage = "New Warning message1";
            MessageCreator.CreateMessage(textMessage, TraceEventType.Warning, SubType.General, collision);


            textMessage = "New Warning message2";
            MessageCreator.CreateMessage(textMessage, TraceEventType.Warning, SubType.General, collision);


            textMessage = "New Warning message3";
            MessageCreator.CreateMessage(textMessage, TraceEventType.Warning, SubType.SystemConnection, collision);


            //Error mes
            textMessage = "New Error message11";
            MessageCreator.CreateMessage(textMessage, TraceEventType.Error, SubType.BuildCollision, collision);

            textMessage = "New Error message2";
            MessageCreator.CreateMessage(textMessage, TraceEventType.Error, SubType.General, collision);

            //Resume mes
            textMessage = "New resume message1";
            collision = new ClsnInfo(1, 1178, 154742) { IsResolved = false };
            MessageCreator.CreateResumeMessage(textMessage, collision);

            collision = new ClsnInfo(2, 1178, 154742) { IsResolved = true};
            textMessage = "New resume message2";
            MessageCreator.CreateResumeMessage(textMessage, collision);

            textMessage = "New resume message3";
            collision = new ClsnInfo(3, 1178, 154742) { IsResolved = true };
            MessageCreator.CreateResumeMessage("", collision);



            Log log = new Log();
            log.Create();

            Console.WriteLine("Log created!");
        }
    }
}
