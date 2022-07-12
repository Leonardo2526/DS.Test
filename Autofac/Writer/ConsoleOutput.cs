using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.AutofacTest.Writer
{
    public interface IOutput
    {
        void Write(string content);
    }

    // This implementation of the IOutput interface
    // is actually how we write to the Console. Technically
    // we could also implement IOutput to write to Debug
    // or Trace... or anywhere else.
    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }

    public class ConsoleOutput1 : IOutput
    {

        public ConsoleOutput1(string s)
        {
            S = s;
        }

        public string S { get; }

        public void Write(string content)
        {
            Console.WriteLine(content + " S");
        }
    }
}
