using DS.ConsoleApp.XYZTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DS.TestProject.VS
{
    [TestClass]
    public class XYZOperationTest
    {       

        [DataTestMethod]
        [DynamicData(nameof(GetBasis), DynamicDataSourceType.Method)]
        public void XYZOrientationTest(XYZ vector1, XYZ vector2, XYZ vector3)
        {
            Assert.IsTrue(XYZOperation.
                Is3DOrientationEqualToOrigin(vector1, vector2, vector3));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetBasisForFail), DynamicDataSourceType.Method)]
        public void XYZOrientationFailTest(XYZ vector1, XYZ vector2, XYZ vector3)
        {
            Assert.IsTrue(!XYZOperation.
                Is3DOrientationEqualToOrigin(vector1, vector2, vector3));
        }

        public static IEnumerable<object[]> GetBasis()
        {
            yield return new object[] { new XYZ(1, 0, 0), new XYZ(0, 1, 0), new XYZ(0, 0, 1) };
            yield return new object[] { new XYZ(10, 0, 0), new XYZ(0, 1, 0), new XYZ(0, 0, 1) };            
        }

        public static IEnumerable<object[]> GetBasisForFail()
        {
            yield return new object[] { new XYZ(-1, 0, 0), new XYZ(0, 1, 0), new XYZ(0, 0, 1) };
            yield return new object[] { new XYZ(1, 0, 0), new XYZ(0, -1, 0), new XYZ(0, 0, 1) };
        }


    }
}
