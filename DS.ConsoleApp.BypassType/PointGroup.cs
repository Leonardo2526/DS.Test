using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.BypassType
{
    abstract class PointGroup
    {
        public double P1 { get; set; }
        public double P2 { get; set; }

        public PointGroup(double p1, double p2)
        {
            P1 = p1;
            P2 = p2;
        }
        // фабричный метод
        abstract public void Create();
    }
}
