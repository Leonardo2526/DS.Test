using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.BypassType
{
    class Type1PointModelFactory : PointModelFactory
    {
        public Type1PointModelFactory(double p1, double p2)
        {
            CreateL0(p1, p2);
            CreateL1(p1, p2);
            CreateL2(p1, p2);
        }

        public override PointGroup CreateL0(double p1, double p2)
        {
            return new Type1PointGroupL0(p1, p2);
        }

        public override PointGroup CreateL1(double p1, double p2)
        {
            return new Type1PointGroupL1(p1, p2);
        }

        private void CreateL2(double p1, double p2)
        {
            Console.WriteLine($"Cretate type1 group L2 {p1}, {p2}.");
        }
    }

    class Type1PointGroupL0 : PointGroup
    {
        public Type1PointGroupL0(double p1, double p2) : base(p1, p2)
        { Create(); }

        public override void Create()
        {
            Console.WriteLine($"Cretate type1 group L0 {P1}, {P2}.");
        }
    }

    class Type1PointGroupL1 : PointGroup
    {
        public Type1PointGroupL1(double p1, double p2) : base(p1, p2)
        { Create(); }

        public override void Create()
        {
            Console.WriteLine($"Cretate type1 group L1 {P1}, {P2}.");
        }
    }

   
}
