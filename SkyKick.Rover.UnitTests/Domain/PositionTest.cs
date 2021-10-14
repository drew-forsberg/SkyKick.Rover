using System;
using Shouldly;
using SkyKick.Rover.Domain;
using SkyKick.Rover.UnitTests.Support;
using Xunit;

namespace SkyKick.Rover.UnitTests.Domain
{
    public class PositionTest
    {
        [Theory, AutoMoqData]
        public void Constructor_X_Invalid_Should_Throw_ArgumentOutOfRangeException(int y, Orientation orientation)
        {
            // Arrange
            const int x = -1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Position(x, y, orientation));
        }

        [Theory, AutoMoqData]
        public void Constructor_Y_Invalid_Should_Throw_ArgumentOutOfRangeException(int x, Orientation orientation)
        {
            // Arrange
            const int y = -1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Position(x, y, orientation));
        }

        [Theory, AutoMoqData]
        public void Constructor_Valid_Should_Set_Properties(int x, int y, Orientation orientation)
        {
            // Act
            var position = new Position(x, y, orientation);

            // Assert
            position.X.ShouldBe(x);
            position.Y.ShouldBe(y);
            position.Orientation.ShouldBe(orientation);
        }
    }
}
