using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    internal static  class OperandTest
    {
        public static void Run()
        {
            List<string> strings = new List<string>();
            //List<string> strings = new List<string>()
            //{
            //    "A" , "B" 
            //};

            List<string> strings1 = new List<string>()
            {
                "B" , "C"
            };

            string str = strings.Any() ? strings.Last() : strings1.Last();
            Console.WriteLine(str);

            //foreach (var item in strings1)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
