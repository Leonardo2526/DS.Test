using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.MainUtils;

namespace DS.ConsoleApp.XYZTest
{
    public static class XYZOperation
    {
        /// <summary>
        /// Check if three vectors system have orientation (left or right) like origin
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="vector3"></param>
        /// <returns>Return true if three vectors system have orientation like origin.</returns>
        public static bool Is3DOrientationEqualToOrigin(XYZ vector1, XYZ vector2, XYZ vector3)
        {
            double[,] matrix = CreateMatrix3D(vector1, vector2, vector3);
            double det = Matrix.GetMatrixDeterminant(matrix);

            if (det > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get matrix's determinant created by 3 vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="vector3"></param>
        /// <returns>Return matrix determinant value</returns>
        private static double GetDeterminantByVectors(XYZ vector1, XYZ vector2, XYZ vector3)
        {
            double[,] matrix = CreateMatrix3D(vector1, vector2, vector3);
            return Matrix.GetMatrixDeterminant(matrix);
        }

        /// <summary>
        /// Create 3D matrix by 3 vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="vector3"></param>
        /// <returns>Return 3D matrix.</returns>
        private static double[,] CreateMatrix3D(XYZ vector1, XYZ vector2, XYZ vector3)
        {
            List<XYZ> result = new List<XYZ>()
            {
                vector1, vector2, vector3
            };

            double[,] matrix = new double[3, 3];

            for (int i = 0; i < 3; i++)
            {
                matrix[i, 0] = result[i].X;
                matrix[i, 1] = result[i].Y;
                matrix[i, 2] = result[i].Z;
            }

            return matrix;
        }

        /// <summary>
        /// Get cross product(vector product) for right hand side cartesian coordinate system
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static XYZ GetCrossProduct(XYZ a, XYZ b)
        {
            return new XYZ(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
        }

        /// <summary>
        /// Get dot product or scalar product of two vectors.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double GetDotProduct(XYZ a, XYZ b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        /// <summary>
        /// Get tripple product for right hand side cartesian coordinate system
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double GetTrippleProduct(XYZ a, XYZ b, XYZ c)
        {
            return GetDeterminantByVectors(a, b, c);
        }


        /// <summary>
        /// Get length of vector.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static double GetLength(XYZ a)
        {
            return Math.Sqrt(GetDotProduct(a, a));
        }

        /// <summary>
        /// Check if two vectors are colliner.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Return true if two vectors are colliner.</returns>
        public static bool Collinearity(XYZ a, XYZ b)
        {
            XYZ crossProduct = GetCrossProduct(a, b);
            if (GetLength(crossProduct) == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if two vectors are coplanar.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Return true if two vectors are coplanar.</returns>
        public static bool Coplanarity(XYZ a, XYZ b, XYZ c)
        {
            if(GetTrippleProduct(a, b, c) == 0)
            {
                return true;
            }
            return false;
        }

    }
}
