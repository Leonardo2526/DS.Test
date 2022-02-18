using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesTest
{
    class Class2
    {
        private int myVar1;

        public int MyProperty1
        {
            get 
            { 
                return MyProperty + 10; 
            }
        }

        private int myVar2;

        public int MyProperty2
        {
            get { return myVar2; }
            set { myVar2 = value; }
        }


        public int MyProperty { get; set; }

    }
}
