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
        private KeyValuePair<TraceEventType, List<Message>> item;

        public MessageStringCreator(KeyValuePair<TraceEventType, List<Message>> item)
        {
            this.item = item;
        }

        public string Create()
        {
            string messages = "\n\n";
            int i = 0;
            foreach (var message in item.Value)
            {
                i++;
                messages += $"{item.Key} {i}: " +
                $"Collision {message.ClsnInfo.ClsnNumber} (Id1 = {message.ClsnInfo.MECCurve1Id}, Id2 = {message.ClsnInfo.MECCurve2Id}) - " +
                $"{message.SubType} {item.Key.ToString().ToLower()}. {message.Text}\n";
            }

            return messages;
        }

        public string CreateAccount()
        {
            string subTypesStrins = "\n\n";
            int count = item.Value.Count;
            subTypesStrins += $"Total {item.Key.ToString().ToLower()}s count: {count}\n";

            var subTypes = SortBySubTypes(item.Value);

            foreach (var subType in subTypes)
            {
                subTypesStrins += "   " + subType.Key + " - " + subType.Value.Count + "\n";
            }

            return subTypesStrins;
        }


        private Dictionary<SubType, List<Message>> SortBySubTypes(List<Message> messages)
        {
            Dictionary<SubType, List<Message>> messagesByEvTypes = new Dictionary<SubType, List<Message>>();

            foreach (var message in messages)
            {
                SubType evtype = message.SubType;
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


        public string CreateResume()
        {
            string messages = "\n\n";
            foreach (var message in item.Value)
            {
                string isres = GetResolve(message.ClsnInfo);

                messages += $"Collision {message.ClsnInfo.ClsnNumber} " +
                    $"(Id1 = {message.ClsnInfo.MECCurve1Id}, Id2 =  {message.ClsnInfo.MECCurve2Id}) " +
                $"- {isres} {message.Text}\n";
            }

            return messages;
        }

        private string GetResolve(ClsnInfo clsnInfo)
        {
            if (clsnInfo.IsResolved)
            {
                return "Resolved";
            }
            else
            {
               return "Unresolved";
            }
        }

        private (int resCol, int unResCol) GetCollisionsCount(List<Message> messages)
        {
            int resCol = 0, unResCol = 0;
            foreach (Message message in messages)
            {
                if (message.ClsnInfo.IsResolved)
                {
                    resCol++;
                }
                else
                {
                    unResCol++;
                }
            }

            return (resCol, unResCol);
        }

        public string CreateResumeAccount(KeyValuePair<TraceEventType, List<Message>> resume, 
            Dictionary<TraceEventType, List<Message>>  messagesByEvTypes)
        {
            (int resCol, int unResCol) = GetCollisionsCount(resume.Value);

            string outString = "\n\n";

            outString += $"Total collisions count: {resCol + unResCol}\n";
            outString += $"   Resolved collisions: {resCol}\n";
            outString += $"   Unresolved collisions: {unResCol}\n";

            outString += "\n\n";

            messagesByEvTypes.Remove(resume.Key);

            foreach (var evType in messagesByEvTypes)
            {
                outString += $"Total {evType.Key.ToString().ToLower()}s count: {evType.Value.Count}\n";
            }

            return outString;
        }
    }
}
