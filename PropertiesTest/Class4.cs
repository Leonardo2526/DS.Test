using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesTest
{
    internal class Class4
    {
        public Class4()
        {

        }

        //get value only once and save on it to get next
        public int Prop1 { get; } = GetProp();

        //get value only once and save on it to get next
        public static int Prop2 { get; } = GetProp2();

        //get value only once and save on it to get next
        public int Prop3 { get; } = new Class1().MyProperty1;

        //initiate get value every time when apply
        public int Prop4

        {
            get
            {
                return GetProp();
            }
        }


        private static int GetProp()
        {
            int i = 0;
            return i;
        }

        private static int GetProp2()
        {
            int i = 1;
            return i;
        }
    }
}
