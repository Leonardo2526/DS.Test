using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    internal static class StringTest
    {
        public static bool IsStringContains(string s, string text)
        {
            if (s.Contains(text))
            {
                return true;
            }
            return false; 
        }
    }
}
