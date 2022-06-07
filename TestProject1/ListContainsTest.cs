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
    public class ListContainsTest
    {
        [DataTestMethod]
        [DynamicData(nameof(ListObjects))]
        public void TestPointList(List<Point> list)
        {
            Point point = new Point(2, 3);
            Assert.IsFalse(list.Contains(point));
        }

        [DataTestMethod]
        [DynamicData(nameof(ListExtObjects))]
        public void TestPointExtList1(List<PointExp> list)
        {
            PointExp point = new PointExp(2, 3);
            Assert.IsTrue(list.Contains(point));
        }


        [DataTestMethod]
        [DynamicData(nameof(GetListObjects), DynamicDataSourceType.Method)]
        public void TestPointExtList2(List<PointExp> list)
        {
            PointExp point = new PointExp(2, 3);
            Assert.IsTrue(list.Contains(point));
        }

        public static IEnumerable<object[]> ListObjects
        {
            get
            {
                return new[]
                {
                    new object[] { new List<Point> { new Point(0, 0), new Point(2, 3) } },
                    new object[] { new List<Point> { new Point(1, 2), new Point(2, 3) } }
                };
            }
        }

        public static IEnumerable<object[]> ListExtObjects
        {
            get
            {
                return new[]
                {
                    new object[] { new List<PointExp> { new PointExp(0, 0), new PointExp(2, 3) } },
                    new object[] { new List<PointExp> { new PointExp(1, 2), new PointExp(2, 3) } }
                };
            }
        }

        public static IEnumerable<object[]> GetListObjects()
        {
            yield return new object[] { new List<PointExp> { new PointExp(0, 0), new PointExp(2, 3) } };
            yield return new object[] { new List<PointExp> { new PointExp(1, 2), new PointExp(2, 3) } };
        }

    }
}
