using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.XYZTest
{

    public class Basis
    {
        public Basis(XYZ basisX, XYZ basisY, XYZ basisZ)
        {
            X = basisX;
            Y = basisY;
            Z = basisZ;
        }

        public XYZ X { get; private set; }
        public XYZ Y { get; private set; }
        public XYZ Z { get; private set; }
       
    }
}

