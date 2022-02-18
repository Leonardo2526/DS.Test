using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesTest
{
    class Class1
    {
        public int MyProperty1 { get; } = 5;

        private int priv = 4;
        public int MyProperty2
        { 
            get 
            {
                int sum = MyProperty1 + MyProperty3 + 5;
                return priv; 
            }
            set
            {
                priv = value * 2;
            }
        }

        public int MyProperty3 { get { return 5; } }
    }
}
