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
            Collision collision = new Collision();
            collision.Id = 0;
            collision.MECCurve1Id = 11;
            collision.MECCurve2Id = 12;


            MessageModel messageModel = new MessageModel();
            string textMessage;

            //Warning mes
            textMessage = "New Warning message1";
            messageModel.AddMessage(textMessage, TraceEventType.Warning, SubType.General, collision);


            textMessage = "New Warning message2";
            messageModel.AddMessage(textMessage, TraceEventType.Warning, SubType.General, collision);


            textMessage = "New Warning message3";
            messageModel.AddMessage(textMessage, TraceEventType.Warning, SubType.SystemConnection, collision);


            //Error mes
            textMessage = "New Error message1";
            messageModel.AddMessage(textMessage, TraceEventType.Error, SubType.BuildCollision, collision);

            textMessage = "New Error message2";
            messageModel.AddMessage(textMessage, TraceEventType.Error, SubType.General, collision);

            //Resume mes
            textMessage = "New resume message1";
            messageModel.AddResumeMessage(textMessage, collision);


            textMessage = "New resume message2";
            messageModel.AddResumeMessage(textMessage, collision);

            textMessage = "New resume message3";
            collision.IsResolved = true;
            messageModel.AddResumeMessage("", collision);



            Log log = new Log();
            log.Create(messageModel);

            Console.WriteLine("Log created!");
        }
    }
}
