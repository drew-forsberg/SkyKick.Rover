using System;
using Shouldly;
using SkyKick.Rover.Domain;
using SkyKick.Rover.UnitTests.Support;
using Xunit;

namespace SkyKick.Rover.UnitTests.Domain
{
    public class GridTest
    {
        [Theory, AutoMoqData]
        public void Constructor_Parameters_X_Invalid_Should_Throw_ArgumentOutOfRangeException(int y)
        {
            // Arrange
            const int x = -1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(x, y));
        }

        [Theory, AutoMoqData]
        public void Constructor_Parameters_Y_Invalid_Should_Throw_ArgumentOutOfRangeException(int x)
        {
            // Arrange
            const int y = -1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(x, y));
        }

        [Theory, AutoMoqData]
        public void Constructor_Parameters_Valid_Should_Set_Properties(int x, int y)
        {
            // Act
            var position = new Grid(x, y);

            // Assert
            position.X.ShouldBe(x);
            position.Y.ShouldBe(y);
        }
    }
}
