using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    internal class WarningMessageCreator : MessageCreator
    {
        public override Message Create(string text, SubType subType)
        {
            Message message = new WarningMessage(subType, text, CreatedMessages.Count + 1);
            CreatedMessages.Add(message);

            foreach (KeyValuePair<SubType, int> item in SubTypes)
            {
                var t = (SubType)item.Key;
                if (subType == t)
                {
                    SubTypes[item.Key] = item.Value + 1;
                    break;
                }
             }

            return message;
        }
    }
}
