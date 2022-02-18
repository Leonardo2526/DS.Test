using System;
using System.Collections.Generic;

namespace ForCycleTest
{
    class SymmetricSequence
    {
        static int length = 20;
        static int startValue = 0;
      

        static void Main(string[] args)
        {
            List<int> list = new List<int>()
            {
                startValue-1, startValue+1, startValue
            };

            for (int i = startValue; i <= length; i = GetNext(i, list))
                Console.WriteLine(i);

            Console.ReadLine();
        }

        static int GetNext(int i, List<int> list)
        {
            list[0] = list[1];
            list[1] = list[2];
            list[2] = i;

            return list[0] + list[1] - list[2];
        }
    }
}
