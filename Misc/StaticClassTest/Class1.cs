using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.StaticClassTest
{
    internal class Class1
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Run(int d, string n)
        {
            StaticClass.Field1 = d;
            StaticClass.Field2 = n;

            Id = StaticClass.Field1;
            Name = StaticClass.Field2;
        }

        public void OutputStaticData()
        {
            Console.WriteLine($"{this.GetType().Name} StaticClass.Field1 - {StaticClass.Field1}");
        }
    }
}
