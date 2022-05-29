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
        public void SumTests(IEnumerable<double> list1)
        {
            //XYZOperation.Is3DOrientationEqualToOrigin(list1.GetEnumerator());
        }

        public static IEnumerable<object[]> GetTestData1()
        {
            yield return new object[] { new double[1, 0, 0], new double[0, 1, 0], new double[0, 0, 1]};
        }
      
    }
}
