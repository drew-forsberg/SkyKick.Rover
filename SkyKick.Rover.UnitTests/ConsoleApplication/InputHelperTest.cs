using System;
using System.Collections.Generic;
using Shouldly;
using SkyKick.Rover.ConsoleApplication;
using SkyKick.Rover.Domain;
using Xunit;

namespace SkyKick.Rover.UnitTests.ConsoleApplication
{
    public class InputHelperTest
    {
        [Theory]
        [InlineData(null)]
        public void CreateGrid_InputText_Null_Should_Throw_ArgumentNullException(string inputText)
        {
            // Arrange
            var inputHelper = new InputHelper();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => inputHelper.CreateGrid(inputText));
        }

        [Theory]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("1 ")]
        [InlineData("1 A")]
        public void CreateGrid_InputText_Invalid_Should_Throw_ArgumentException(string inputText)
        {
            // Arrange
            var inputHelper = new InputHelper();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => inputHelper.CreateGrid(inputText));

            exception.Message.ShouldContain("is not a valid set of grid dimensions");
        }

        [Theory]
        [InlineData("5 5", 5, 5)]
        [InlineData("50 50", 50, 50)]
        [InlineData("500 500", 500, 500)]
        public void CreateGrid_InputText_Valid_Should_Return_Grid(string inputText, int expectedX, int expectedY)
        {
            // Arrange
            var inputHelper = new InputHelper();

            // Act
            var grid = inputHelper.CreateGrid(inputText);

            // Assert
            grid.ShouldNotBeNull();
            grid.X.ShouldBe(expectedX);
            grid.Y.ShouldBe(expectedY);
        }

        [Theory]
        [InlineData(" 5 5 ", 5, 5)]
        public void CreateGrid_InputText_Valid_NonStandardFormatting_Should_Return_Grid(string inputText, int expectedX, int expectedY)
        {
            // Arrange
            var inputHelper = new InputHelper();

            // Act
            var grid = inputHelper.CreateGrid(inputText);

            // Assert
            grid.ShouldNotBeNull();
            grid.X.ShouldBe(expectedX);
            grid.Y.ShouldBe(expectedY);
        }

        [Theory]
        [InlineData(null)]
        public void CreatePosition_InputText_Null_Should_Throw_ArgumentNullException(string inputText)
        {
            // Arrange
            var inputHelper = new InputHelper();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => inputHelper.CreatePosition(inputText));
        }

        [Theory]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("1 ")]
        [InlineData("1 2")]
        [InlineData("1 2 ")]
        [InlineData("1 2 Q")]
        public void CreatePosition_InputText_Invalid_Should_Throw_ArgumentException(string inputText)
        {
            // Arrange
            var inputHelper = new InputHelper();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => inputHelper.CreatePosition(inputText));

            exception.Message.ShouldContain("is not a valid position");
        }

        [Theory]
        [InlineData("5 5 N", 5, 5, Orientation.N)]
        [InlineData("50 50 E", 50, 50, Orientation.E)]
        [InlineData("500 500 S", 500, 500, Orientation.S)]
        [InlineData("5000 5000 W", 5000, 5000, Orientation.W)]
        public void CreatePosition_InputText_Valid_Should_Return_Position(string inputText, int expectedX, int expectedY, Orientation expectedOrientation)
        {
            // Arrange
            var inputHelper = new InputHelper();

            // Act
            var position = inputHelper.CreatePosition(inputText);

            // Assert
            position.ShouldNotBeNull();
            position.X.ShouldBe(expectedX);
            position.Y.ShouldBe(expectedY);
            position.Orientation.ShouldBe(expectedOrientation);
        }

        [Theory]
        [InlineData(" 5 5 n ", 5, 5, Orientation.N)]
        [InlineData(" 50 50 e ", 50, 50, Orientation.E)]
        [InlineData(" 500 500 s ", 500, 500, Orientation.S)]
        [InlineData(" 5000 5000 w ", 5000, 5000, Orientation.W)]
        public void CreatePosition_InputText_Valid_NonStandardFormatting_Should_Return_Position(string inputText, int expectedX, int expectedY, Orientation expectedOrientation)
        {
            // Arrange
            var inputHelper = new InputHelper();

            // Act
            var position = inputHelper.CreatePosition(inputText);
            // Assert
            position.ShouldNotBeNull();
            position.X.ShouldBe(expectedX);
            position.Y.ShouldBe(expectedY);
            position.Orientation.ShouldBe(expectedOrientation);
        }

        [Fact]
        public void CreateMovementPlan_InputText_Null_Should_Throw_ArgumentNullException()
        {
            // Arrange
            var inputHelper = new InputHelper();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => inputHelper.CreateMovementPlan(default));
        }

        [Theory]
        [InlineData("")]
        [InlineData("L1")]
        [InlineData("QWERTY")]
        [InlineData("99999")]
        public void CreateMovementPlan_InputText_Invalid_Should_Throw_ArgumentException(string inputText)
        {
            // Arrange
            var inputHelper = new InputHelper();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => inputHelper.CreateMovementPlan(inputText));

            exception.Message.ShouldContain("is not a valid movement plan");
        }

        [Fact]
        public void CreateMovementPlan_InputText_Valid_Should_Return_MovementPlan()
        {
            // Arrange
            var inputHelper = new InputHelper();
            const string inputText = "LMRM";
            var commands = new List<Command>
            {
                Command.L,
                Command.M,
                Command.R,
                Command.M
            };

            // Act
            var movementPlan = inputHelper.CreateMovementPlan(inputText);

            // Assert
            movementPlan.ShouldNotBeNull();
            movementPlan.Commands.ShouldBe(commands);
        }

        [Fact]
        public void CreateMovementPlan_InputText_Valid_NonStandardFormatting_Should_Return_MovementPlan()
        {
            // Arrange
            var inputHelper = new InputHelper();
            const string inputText = " rml ";
            var commands = new List<Command>
            {
                Command.R,
                Command.M,
                Command.L
            };

            // Act
            var movementPlan = inputHelper.CreateMovementPlan(inputText);

            // Assert
            movementPlan.ShouldNotBeNull();
            movementPlan.Commands.ShouldBe(commands);
        }
    }
}
