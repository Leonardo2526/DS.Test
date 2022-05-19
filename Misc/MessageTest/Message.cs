using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    public struct Message
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
    }

  
}
