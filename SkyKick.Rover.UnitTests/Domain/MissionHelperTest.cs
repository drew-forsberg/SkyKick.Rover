using System;
using Shouldly;
using SkyKick.Rover.Domain;
using Xunit;

namespace SkyKick.Rover.UnitTests.Domain
{
    public class MissionHelperTest
    {
        private static readonly Grid Grid = new Grid(5, 5);

        [Theory]
        [InlineData(Orientation.N, Orientation.W)]
        [InlineData(Orientation.E, Orientation.N)]
        [InlineData(Orientation.S, Orientation.E)]
        [InlineData(Orientation.W, Orientation.S)]
        public void RotateLeft_Should_Return_Expected_Orientation(Orientation startingOrientation, Orientation endingOrientation)
        {
            // Arrange
            var position = new Position(0, 0, startingOrientation);
            var missionHelper = new MissionHelper();

            // Act
            missionHelper.RotateLeft(position);

            // Assert
            position.Orientation.ShouldBe(endingOrientation);
        }

        [Theory]
        [InlineData(Orientation.N, Orientation.E)]
        [InlineData(Orientation.E, Orientation.S)]
        [InlineData(Orientation.S, Orientation.W)]
        [InlineData(Orientation.W, Orientation.N)]
        public void RotateRight_Should_Return_Expected_Orientation(Orientation startingOrientation, Orientation endingOrientation)
        {
            // Arrange
            var position = new Position(0, 0, startingOrientation);
            var missionHelper = new MissionHelper();

            // Act
            missionHelper.RotateRight(position);

            // Assert
            position.Orientation.ShouldBe(endingOrientation);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 4)]
        [InlineData(4, 5)]
        public void Move_North_Should_Return_Expected_Position(int startingY, int endingY)
        {
            // Arrange
            const int startingX = 0;

            var position = new Position(startingX, startingY, Orientation.N);
            var missionHelper = new MissionHelper();

            // Act
            missionHelper.Move(Grid, position);

            // Assert
            position.X.ShouldBe(startingX);
            position.Y.ShouldBe(endingY);
        }

        [Theory]
        [InlineData(5, 4)]
        [InlineData(4, 3)]
        [InlineData(3, 2)]
        [InlineData(2, 1)]
        [InlineData(1, 0)]
        public void Move_South_Should_Return_Expected_Position(int startingY, int endingY)
        {
            // Arrange
            const int startingX = 0;

            var position = new Position(startingX, startingY, Orientation.S);
            var missionHelper = new MissionHelper();

            // Act
            missionHelper.Move(Grid, position);

            // Assert
            position.X.ShouldBe(startingX);
            position.Y.ShouldBe(endingY);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 4)]
        [InlineData(4, 5)]
        public void Move_East_Should_Return_Expected_Position(int startingX, int endingX)
        {
            // Arrange
            const int startingY = 0;

            var position = new Position(startingX, startingY, Orientation.E);
            var missionHelper = new MissionHelper();

            // Act
            missionHelper.Move(Grid, position);

            // Assert
            position.X.ShouldBe(endingX);
            position.Y.ShouldBe(startingY);
        }

        [Theory]
        [InlineData(5, 4)]
        [InlineData(4, 3)]
        [InlineData(3, 2)]
        [InlineData(2, 1)]
        [InlineData(1, 0)]
        public void Move_West_Should_Return_Expected_Position(int startingX, int endingX)
        {
            // Arrange
            const int startingY = 0;

            var position = new Position(startingX, startingY, Orientation.W);
            var missionHelper = new MissionHelper();

            // Act
            missionHelper.Move(Grid, position);

            // Assert
            position.X.ShouldBe(endingX);
            position.Y.ShouldBe(startingY);
        }

        [Fact]
        public void Move_North_Invalid_Should_Throw_ArgumentOutOfRangeException()
        {
            // Arrange
            const int startingX = 0;
            const int startingY = 5;

            var position = new Position(startingX, startingY, Orientation.N);
            var missionHelper = new MissionHelper();

            // Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => missionHelper.Move(Grid, position));

            // Assert
            exception.Message.ShouldStartWith("Moves exceed the vertical limit of the current grid");
        }

        [Fact]
        public void Move_East_Invalid_Should_Throw_ArgumentOutOfRangeException()
        {
            // Arrange
            const int startingX = 5;
            const int startingY = 0;

            var position = new Position(startingX, startingY, Orientation.E);
            var missionHelper = new MissionHelper();

            // Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => missionHelper.Move(Grid, position));

            // Assert
            exception.Message.ShouldStartWith("Moves exceed the horizontal limit of the current grid");
        }

        [Fact]
        public void Move_South_Invalid_Should_Throw_ArgumentOutOfRangeException()
        {
            // Arrange
            const int startingX = 0;
            const int startingY = 0;

            var position = new Position(startingX, startingY, Orientation.S);
            var missionHelper = new MissionHelper();

            // Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => missionHelper.Move(Grid, position));

            // Assert
            exception.Message.ShouldStartWith("Moves exceed the vertical limit of the current grid");
        }

        [Fact]
        public void Move_West_Invalid_Should_Throw_ArgumentOutOfRangeException()
        {
            // Arrange
            const int startingX = 0;
            const int startingY = 0;

            var position = new Position(startingX, startingY, Orientation.W);
            var missionHelper = new MissionHelper();

            // Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => missionHelper.Move(Grid, position));

            // Assert
            exception.Message.ShouldStartWith("Moves exceed the horizontal limit of the current grid");
        }
    }
}
