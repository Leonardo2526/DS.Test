using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTest
{
    class Application : IApplication
    {
        IMessage _message;
        ICalculation _calculation;

        public Application(IMessage message, ICalculation calculation)
        {
            _message = message;
            _calculation = calculation;
        }

        public void Run()
        {
            _message.HelloMessage();
            _calculation.GetSum();
        }
    }
}
