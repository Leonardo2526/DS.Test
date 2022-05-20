using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}