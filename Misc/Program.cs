using System;

namespace Misc
{
    class Program
    {
        static void Main(string[] args)
        {
            //LineIntersectionTest.RunTest();
            //LoopBackward.RunLoop();
            string? line = null;
            GetString(line);
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
