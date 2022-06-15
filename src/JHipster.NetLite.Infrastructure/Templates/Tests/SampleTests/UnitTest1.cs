using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace SampleTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Heres an example with FluentAssertions
            //Arrange
            var number = 1;

            //Act
            number += 1;

            //Assert
            number.Should().Be(2);
        }
    }
}
