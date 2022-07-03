using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesTest
{
    internal class Class3
    {
        public Class3()
        {
            MyProperty = 0;
        }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set 
            { 
                myVar = value; 
            }
        }

    }
}
