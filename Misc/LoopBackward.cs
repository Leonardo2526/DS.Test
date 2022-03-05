using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    static class LoopBackward
    {

        public static void RunLoop()
        {
            var newList = new List<int>()
            {
                1,2,3,4,5
            };

         for (int i = newList.Count; i-- >0;)
            {
                Console.WriteLine(newList[i]);
            }

        }
            

    }
}
