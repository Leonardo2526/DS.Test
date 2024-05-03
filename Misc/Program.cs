using MoreLinq;
using System;
using System.Collections.Generic;

namespace Misc
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.ReadLine();
        }

        static int GetIndex(string line)
        {
            string symb = "|";
            int charLocation = line.IndexOf(symb, StringComparison.Ordinal);

            return charLocation;
        }
    }

    public class TestClass
    {
        private string _s;

        public TestClass(string s)
        {
            _s = s;
        }

        public string Prop1 => GetString();

        private string GetString()
        {
            var s = "GetString";
            Console.WriteLine(s);

            return s;
        }

        public void Change()
        {
            _s = "new s";
        }
    }

}
