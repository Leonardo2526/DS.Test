using System;
using System.Collections.Generic;
using System.Linq;
using Misc.MessageTest;
using System.Diagnostics;
using Misc.StaticClassTest;
using System.Threading.Tasks;

namespace Misc
{
    class Program    
    {
        //static void Main(string[] args)
        //{
        //    Output.Run();
        //    //MessagedOutput.Output();
        //    Console.ReadLine();
        //}


        static async Task Main0(string[] args)
        {
            await Output.RunAsync();
            //MessagedOutput.Output();
            Console.ReadLine();
        }

        private static void GetString(string? line)
        {
            if (line is not null)
            {
                Console.WriteLine(line.ToLower());
            }
        }

        static void Main(string[] args)
        {
            var s = "sdgh 56 ijkj";
            var text = "a";

            Console.WriteLine(StringTest.IsStringContains(s, text));

            //string str = null;
            //string str = "test";
            //Console.WriteLine(str?.Length);
            Console.ReadKey();
        }
    }
}
