using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.StaticTest
{
    internal class Class2
    {
        public Class2()
        {
            i++;
        }

        public int MyProperty
        {
            get
            {
                return i;
            }
        }
        public int MyProperty2 { get; set; }

        private static int i;

        public void Operation()
        {
            i++;
        }
    }
}
