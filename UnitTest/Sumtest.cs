using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class Sumtest
    {
        [Fact]
        public void Sum_Should()
        {
            //Arrange
            double sum = 5;

            //Act
            double sumResult= Sum.GetSum(2, 3);

            //Assert
            Assert.Equal(sum, sumResult);
        }
    }
}
