using System;
using System.Collections.Generic;
using System.Linq;
using Misc.MessageTest;

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

            //Create list of message creators
            List<MessageCreator> messageCreators = new List<MessageCreator>();
            messageCreators.Add(new WarningMessageCreator());


            string message = "New Warning message1";
            WarningMessage warningMessage = (WarningMessage)messageCreators.First().Create(message, SubType.General);
            string str = MessageStringCreator.Create(warningMessage, collision);

            message = "New Warning message10";
            warningMessage = (WarningMessage)messageCreators.First().Create(message, SubType.General);
            str += MessageStringCreator.Create(warningMessage, collision);

            message = "New Warning message2";
            warningMessage = (WarningMessage)messageCreators.First().Create(message, SubType.ConnectedElements);
            str += MessageStringCreator.Create(warningMessage, collision);



            str += MessageStringCreator.ResumeWarnings(messageCreators.First());

            Console.WriteLine(str);
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
