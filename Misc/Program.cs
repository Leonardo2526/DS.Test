using System;
using System.Collections.Generic;
using System.Linq;
using Misc.MessageTest;
using System.Diagnostics;

namespace Misc
{
    class Program
    {
        static void Main(string[] args)
        {
            Collision collision = new Collision();
            collision.Id = 0;
            collision.MECCurve1Id = 11;
            collision.MECCurve2Id = 12;


            MessageModel messageModel = new MessageModel();


            string textMessage = "New Warning message1";
            messageModel.AddMessage(textMessage, TraceEventType.Warning, SubType.General, collision);


            textMessage = "New Warning message2";
            messageModel.AddMessage(textMessage, TraceEventType.Warning, SubType.General, collision);


            textMessage = "New Warning message3";
            messageModel.AddMessage(textMessage, TraceEventType.Warning, SubType.SystemConnection, collision);

            textMessage = "New Error message1";
            messageModel.AddMessage(textMessage, TraceEventType.Error, SubType.BuildCollision, collision);

            textMessage = "New Error message2";
            messageModel.AddMessage(textMessage, TraceEventType.Error, SubType.General, collision);

            Log log = new Log();
            log.Create(messageModel);

            Console.WriteLine("Log created!");
            Console.ReadLine();
        }

        private static void GetString(string? line)
        {
            if (line is not null)
            {
                Console.WriteLine(line.ToLower());
            }
        }
    }
}
