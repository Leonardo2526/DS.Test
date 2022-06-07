using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SingletonPattern
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void IsSingletonTest()
        {
            var db = Singleton.Instance;
            var db2 = Singleton.Instance;
            Assert.AreEqual(db, db2);
        }
    }
}
