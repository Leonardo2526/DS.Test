using System;
using System.IO;

namespace UnitTest
{
    static class StringLine
    {
        public static string GetString(string line = null)
        {

            if (line == null)
            {
                throw new ArgumentException("line is nulll", "line");
            }
            else if (line == "")
            {
                throw new FileNotFoundException();
            }

            string newLine = "Newline";
            return line + newLine;
        }
    }
}
