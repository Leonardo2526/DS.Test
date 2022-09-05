using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.XYZTest
{
    public static class Extensions
    {
        /// <summary>
        /// Check if basis is orthogonal
        /// </summary>
        /// <param name="basis"></param>
        /// <returns></returns>
        public static bool IsOrthogonal(this Basis basis, int roundValue = 2)
        {
            double scalarXY = XYZOperation.GetDotProduct(basis.X, basis.Y);
            double scalarXZ = XYZOperation.GetDotProduct(basis.X, basis.Z);
            double scalarYZ = XYZOperation.GetDotProduct(basis.Y, basis.Z);
            if (Math.Round(scalarXY, roundValue) == 0 && 
                Math.Round(scalarXZ, roundValue) == 0 && 
                Math.Round(scalarYZ, roundValue) == 0)
            {
                return true;
            }

            return false;
        }
    }
}
