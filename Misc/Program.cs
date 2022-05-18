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
            //Create list of message creators
            List<MessageCreator> messageCreators = new List<MessageCreator>();
            messageCreators.Add(new WarningMessageCreator());


            string message = "New Warning message1";
            WarningMessage warningMessage = (WarningMessage)messageCreators.First().Create(message, WarningSubType.General.ToString());
            string str = MessageStringCreator.Create(warningMessage);

             message = "New Warning message2";
            warningMessage = (WarningMessage)messageCreators.First().Create(message, WarningSubType.General.ToString());
            str += MessageStringCreator.Create(warningMessage);

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
