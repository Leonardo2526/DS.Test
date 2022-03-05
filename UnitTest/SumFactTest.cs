using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class SumFactTest
    {
        [Fact]
        public void Sum_FactShouldEqual()
        {
            //Arrange
            double expected = 5;

            //Act
            double sumResult= Sum.GetSum(2, 3);

            //Assert
            Assert.Equal(expected, sumResult);
        }

        [Theory]
        [InlineData(2,3,5)]
        [InlineData(2.01,3.56,5.57)]
        [InlineData(double.MaxValue,3.56, double.MaxValue)]
        public void Sum_TheoryShouldEqual(double x, double y, double expected)
        {
            //Arrange

            //Act
            double sumResult = Sum.GetSum(x, y);

            //Assert
            Assert.Equal(expected, sumResult);
        }
    }
}
