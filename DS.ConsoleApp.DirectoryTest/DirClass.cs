using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace DS.ConsoleApp.DirectoryTest
{
    internal static class DirClass
    {
            private static string assemblyPath = Assembly.GetExecutingAssembly().Location;
        private static string assemblyDir = Path.GetDirectoryName(assemblyPath);

        public static string GetDir1()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(assemblyDir);
            return directoryInfo.FullName;
        }

        public static string GetDir2()
        {
            return assemblyPath;
        }
    }
}
