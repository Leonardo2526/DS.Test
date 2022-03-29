using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.BypassType
{
    class Type2PointModelFactory : PointModelFactory
    {
        public Type2PointModelFactory(double p1, double p2)
        {
            CreateL0(p1, p2);
            CreateL1(p1, p2);
        }

        public override PointGroup CreateL0(double p1, double p2)
        {
            return new Type2PointGroupL0(p1, p2);
        }

        public override PointGroup CreateL1(double p1, double p2)
        {
            return new Type2PointGroupL1(p1, p2);
        }
    }

    class Type2PointGroupL0 : PointGroup
    {
        public Type2PointGroupL0(double p1, double p2) : base(p1, p2)
        { Create(); }

        public override void Create()
        {
            Console.WriteLine($"Cretate type2 group L0 {P1}, {P2}.");
        }
    }

    class Type2PointGroupL1 : PointGroup
    {
        public Type2PointGroupL1(double p1, double p2) : base(p1, p2)
        { Create(); }

        public override void Create()
        {
            Console.WriteLine($"Cretate type2 group L1 {P1}, {P2}.");
        }
    }

   
}
