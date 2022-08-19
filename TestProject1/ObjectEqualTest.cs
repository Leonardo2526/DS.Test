using Microsoft.VisualStudio.TestTools.UnitTesting;
using DS.ConsoleApp.TestingObjects;
using System.Collections.Generic;
using System.Linq;
using DS.ConsoleApp.XYZTest;
using System;

namespace DS.TestProject.VS
{
    [TestClass]
    public class ObjectEqualTest
    {

        [TestMethod]
        public void PointTest()
        {
            Point point1 = new Point(0, 0);
            Point point2 = new Point(0, 0);

            bool eq = point1.Equals(point2);

            Assert.IsFalse(eq);
        }

        [TestMethod]
        public void PointExpTest()
        {
            PointExp point1 = new PointExp(0, 0);
            PointExp point2 = new PointExp(0, 0);

            bool eq = point1.Equals(point2);

            Assert.IsTrue(eq);
        }


        [DataTestMethod]
        [DataRow(1, 1, true)]
        [DataRow(1, 1.1, false)]
        [DataRow(1.1, 1.123, true)]

        public void DoubleEqualsTest(double d1, double d2, bool eq)
        {
            bool res = d1.Equals(Math.Round(d2,1));

            Assert.AreEqual(eq, res);
        }


    }
}