using DS.ClassLib.VarUtils;
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


        /// <summary>
        /// Check if basis is orthogonal
        /// </summary>
        public bool IsOrthogonal(int roundValue = 2)
        {
            double scalarXY = XYZOperation.GetDotProduct(X, Y);
            double scalarXZ = XYZOperation.GetDotProduct(X, Z);
            double scalarYZ = XYZOperation.GetDotProduct(Y, Z);
            if (Math.Round(scalarXY, roundValue) == 0 &&
                Math.Round(scalarXZ, roundValue) == 0 &&
                Math.Round(scalarYZ, roundValue) == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get orientation of basis.
        /// </summary>
        /// <returns></returns>
        public BasisOrientation GetOrientaion()
        {
            double[,] matrix = XYZOperation.CreateMatrix3D(X, Y, Z);
            double det = Matrix.GetMatrixDeterminant(matrix);

            if (det > 0)
            {
                return BasisOrientation.Right;
            }

            return BasisOrientation.Left;
        }

    }
}

