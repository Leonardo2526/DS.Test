using Microsoft.VisualStudio.TestTools.UnitTesting;
using DS.ConsoleApp.TestingObjects;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            int q = 1;
            int r = 1;
            Assert.AreEqual(q, r);
        }

        [DataTestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(2, 2, 4)]
        [DataRow(9, 2, 4)]
        public void SumTests(int x, int y, int expected)
        {
            Sum.GetSum(x, y);
            Assert.AreEqual(expected, x + y);
        }

        [DataTestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(2, 2, 4)]
        [DataRow(3, 3, 6)]
        [DataRow(0, 0, 1)] // The test run with this row fails
        public void AddTests2(int x, int y, int expected)
        {
            Assert.AreEqual(expected, x + y);
        }


        [DataTestMethod]
        [DynamicData(nameof(GetTestData1), DynamicDataSourceType.Method)]
        public void CollectionTest(IEnumerable<int> list1)
        {
            CollectionAssert.AllItemsAreNotNull((System.Collections.ICollection)list1);
        }
        public static IEnumerable<object[]> GetTestData1()
        {
            yield return new object[] { new List<int>() { 1 } };
        }

        [DynamicData(nameof(TestMethodInput))]
        [DataTestMethod]
        public void ListTest(List<string> list)
        {
            Assert.AreEqual(2, list.Count);
        }

        public static IEnumerable<object[]> TestMethodInput
        {
            get
            {
                return new[]
                {
                    new object[] { new List<string> { "one" } },
                    new object[] { new List<string> { "one", "two" } },
                    new object[] { new List<string> { "one", "two", "three" }}
                 };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void Test_Add_DynamicData_Method(int a, int b, int expected)
        {
            var actual = a + b;
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { 1, 1, 2 };
            yield return new object[] { 12, 30, 42 };
            yield return new object[] { 14, 1, 15 };
        }
    }
}