using System;
using System.Collections.Generic;
using System.Linq;
using Misc.MessageTest;
using System.Diagnostics;

namespace Misc
{
    class Program
    {
        static void Main(string[] args)
        {
            MessagedOutput.Output();
            Console.ReadLine();
        }

        private static void GetString(string? line)
        {
            if (line is not null)
            {
                Console.WriteLine(line.ToLower());
            }
        }
    }
}
