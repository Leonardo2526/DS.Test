using Microsoft.VisualStudio.TestTools.UnitTesting;
using DS.ConsoleApp.TestingObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.TestingObjects.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void Test1Test()
        {
            Class1 class1 = new Class1();
            class1.Test1();
            Assert.AreEqual(class1.Q, class1.R);
        }
    }
}

namespace DS.ConsoleApp.TestingObjectsTests
{
    internal class Class1Tests
    {
    }
}
