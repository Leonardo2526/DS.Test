using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.IO;

namespace UnitTest
{
    public class StringLineTest
    {
        [Fact]
        public void GetString_ShouldBeValid()
        {
            //Arrange
            string expected = "";

            //Act
            string line = StringLine.GetString("1");

            //Assert
            Assert.True(line.Length > 5);
        }

        [Fact]
        public void GetString_ShouldBeInValid1()
        {
            //Assert
            Assert.Throws<FileNotFoundException>(() => StringLine.GetString(""));
        }

        [Fact]
        public void GetString_ShouldBeInValid2()
        {
            //Assert
            Assert.Throws<ArgumentException>("line", () => StringLine.GetString());
        }
    }
}
