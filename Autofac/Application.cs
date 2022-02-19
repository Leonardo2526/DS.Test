using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTest
{
    public class Application1 : IApplication
    {
        IMessage _message;

        public Application1(IMessage message)
        {
            _message = message;
        }

        public void RunApp()
        {
            _message.HelloMessage();
        }
    }

    public class Application : IApplication
    {
        IPrint _print;

        public Application(IPrint print)
        {
            _print = print;
        }

        public void RunApp()
        {
            _print.Run();
        }
    }
}
