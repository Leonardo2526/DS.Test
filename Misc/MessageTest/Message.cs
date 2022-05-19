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
        public Collision Collision;

        public Message(string text, int id, SubType subType, Collision collision)
        {
            Text = text;
            Id = id;
            SubType = subType;
            Collision = collision;
        }

        public Message(string text, int id, Collision collision)
        {
            Text = text;
            Id = id;
            Collision = collision;
        }
    }

  
}
