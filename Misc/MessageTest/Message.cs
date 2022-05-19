using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    public class Message
    {
        public string Text;
        public int Id;
        public SubType SubType;
        public ClsnInfo Collision;

        public Message(string text, int id, SubType subType, ClsnInfo collision)
        {
            Text = text;
            Id = id;
            SubType = subType;
            Collision = collision;
        }

        public Message(string text, int id, ClsnInfo collision)
        {
            Text = text;
            Id = id;
            Collision = collision;
        }
    }

  
}
