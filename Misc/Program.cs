using System;
using System.Collections.Generic;
using System.Linq;
using Misc.MessageTest;
using System.Diagnostics;
using Misc.StaticClassTest;
using System.Threading.Tasks;
using DS.ClassLib.VarUtils;
using DS.ClassLib.VarUtils.Points;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using static System.Net.Mime.MediaTypeNames;
using Misc.ReflectonsTest;
using Unidecode.NET;

namespace Misc
{
    class Program
    {

        static void Main(string[] args)
        {
            var number = Math.PI;
            var xs1 = (number / (number == 0 ? 1 : Math.Abs(number)));

            Console.WriteLine(xs1);
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
