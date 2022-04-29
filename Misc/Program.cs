using System;

namespace Misc
{
    class Program
    {
        static void Main(string[] args)
        {
            double d = 2.1287624;
            double dRoung = Math.Round(d, 1);
            Console.WriteLine(dRoung);
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
