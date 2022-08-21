using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.Net6Test
{
    internal static class NullClassTest
    {

        internal static void Run()
        {
            string? message = null;
            SayHi(message!);
        }

        static void SayHi(string message)
        {
            Console.WriteLine($"Hello {message}");
        }
    }
}
