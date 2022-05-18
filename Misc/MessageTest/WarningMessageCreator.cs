using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    internal class WarningMessageCreator : MessageCreator
    {
        public override Message Create(string text, string subType)
        {
            Message message = new WarningMessage(subType, text, CreatedMessages.Count + 1);
            CreatedMessages.Add(message);
            
            return message;
        }
    }
}
