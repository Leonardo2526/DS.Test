using DS.ConsoleApp.XYZTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.TestProject.VS
{
    [TestClass]
    public  class XYZCrossProductTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetBasis), DynamicDataSourceType.Method)]
        public void XYZOrientationTest(XYZ vector1, XYZ vector2, XYZ crossProduct)
        {
            Assert.AreEqual(crossProduct, XYZOperation.GetCrossProduct(vector1, vector2));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetFailBasis), DynamicDataSourceType.Method)]
        public void XYZOrientationFailTest(XYZ vector1, XYZ vector2, XYZ crossProduct)
        {
            Assert.AreNotEqual(crossProduct, XYZOperation.GetCrossProduct(vector1, vector2));
        }

        public static IEnumerable<object[]> GetBasis()
        {
            yield return new object[] { new XYZ(1, 0, 0), new XYZ(0, 1, 0), new XYZ(0, 0, 1) };
            yield return new object[] { new XYZ(1, 0, 0), new XYZ(0, -1, 0), new XYZ(0, 0, -1) };
        }

        public static IEnumerable<object[]> GetFailBasis()
        {
            yield return new object[] { new XYZ(1, 0, 0), new XYZ(0, 1, 0), new XYZ(0, 0, 10) };
            yield return new object[] { new XYZ(1, 0, 0), new XYZ(0, -1, 0), new XYZ(10, 0, -1) };
        }
    }
}
