using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTest
{
    public class Message : IMessage
    {
        public void HelloMessage()
        {
            Console.WriteLine("Hello!");
        }
    }
}
