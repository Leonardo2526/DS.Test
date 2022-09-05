using DS.ConsoleApp.XYZTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DS.TestProject.VS
{
    [TestClass]
    public class BasisOrientationTest
    {       

        [DataTestMethod]
        [DynamicData(nameof(GetOthoNormBasis), DynamicDataSourceType.Method)]
        public void OthoNormBasisTest(Basis basis)
        {
            Assert.IsTrue(basis.GetOrientaion() == BasisOrientation.Right);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOthoNormNegateBasis), DynamicDataSourceType.Method)]
        public void OthoNormBasisNegateTest(Basis basis)
        {
            Assert.IsTrue(basis.GetOrientaion() == BasisOrientation.Left);
        }


        [DataTestMethod]
        [DynamicData(nameof(GetVaryBasis), DynamicDataSourceType.Method)]
        public void VaryBasisTest(Basis basis)
        {
            Assert.IsTrue(basis.GetOrientaion() == BasisOrientation.Right);
        }

        public static IEnumerable<object[]> GetOthoNormBasis()
        {
            yield return new object[]
            { new Basis(new XYZ(1, 0, 0), new XYZ(0, 1, 0), new XYZ(0, 0, 1)) };
           
        }

        public static IEnumerable<object[]> GetOthoNormNegateBasis()
        {
            yield return new object[]
           { new Basis(new XYZ(-1, 0, 0), new XYZ(0, 1, 0), new XYZ(0, 0, 1))};
        }

        public static IEnumerable<object[]> GetOthoNormNotRoundBasis()
        {
            double v1 = 1.002;
            double v2 = 0.0003;
            double v3 = 0.000;
            yield return new object[]
            { new Basis(new XYZ(v1, v2, v3), new XYZ(v2, v1, v3), new XYZ(v2, v3, v1)) };
        }

        public static IEnumerable<object[]> GetOthoBasis()
        {
            yield return new object[]
            { new Basis(new XYZ(10, 0, 0), new XYZ(0, 5, 0), new XYZ(0, 0, 8)) };
            yield return new object[]
               { new Basis(new XYZ(-10, 0, 0), new XYZ(0, 1, 0), new XYZ(0, 0, 1))};
        }

        public static IEnumerable<object[]> GetVaryBasis()
        {          
            yield return new object[]
            { new Basis(new XYZ(1, 5, 9), new XYZ(0, 1, 0), new XYZ(0, 0, 1))};

            yield return new object[]
           { new Basis(new XYZ(1.342534, 5.7457, 9.3467), new XYZ(0, 1, 0), new XYZ(0, 0, 1))};
        }

    }
}
