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

namespace Misc
{
    class Program
    {

        static void Main(string[] args)
        {
            PointTest.Run();
            Console.ReadLine();
        }

        static int GetIndex(string line)
        {
            string symb = "|";
            int charLocation = line.IndexOf(symb, StringComparison.Ordinal);

            return charLocation;
        }
    }

}
