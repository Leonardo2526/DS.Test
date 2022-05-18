using Misc.MessageTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    internal static class MessageStringCreator
    {
      public static string Create(Message message)
        {
            return $"{message.TraceEventType} {message.Id}: {message.SubType}. {message.Text}\n";
        }
    }
}
