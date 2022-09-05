using DS.ConsoleApp.XYZTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DS.TestProject.VS
{
    [TestClass]
    public class OrthogonalBasisTest
    {

        [DataTestMethod]
        [DynamicData(nameof(GetOthoNormBasis), DynamicDataSourceType.Method)]
        public void IsOrthogonalNormTests(Basis basis)
        {
            Assert.IsTrue(basis.IsOrthogonal());
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOthoNormNotRoundBasis), DynamicDataSourceType.Method)]
        public void IsOrthogonalNormNotRoundTests(Basis basis)
        {
            Assert.IsTrue(basis.IsOrthogonal());
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOthoBasis), DynamicDataSourceType.Method)]
        public void IsOrthogonalTests(Basis basis)
        {
            Assert.IsTrue(basis.IsOrthogonal());
        }

        [DataTestMethod]
        [DynamicData(nameof(GetVaryBasis), DynamicDataSourceType.Method)]
        public void IsOrthogonalFailTests(Basis basis)
        {
            Assert.IsFalse(basis.IsOrthogonal());
        }

        public static IEnumerable<object[]> GetOthoNormBasis()
        {
            yield return new object[]
            { new Basis(new XYZ(1, 0, 0), new XYZ(0, 1, 0), new XYZ(0, 0, 1)) };
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
        }
    }
}
