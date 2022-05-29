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
    internal class XYZOperationTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData1), DynamicDataSourceType.Method)]
        public void XYZOrientationTest(XYZ vector1, XYZ vector2, XYZ vector3)
        {
            XYZOperation.Is3DOrientationEqualToOrigin(vector1, vector2, vector2);
        }

        public static IEnumerable<object[]> GetTestData1()
        {
            yield return new object[] { new XYZ[1, 0, 0], new XYZ[0, 1, 0], new XYZ[0, 0, 1]};
        }
      
    }
}
