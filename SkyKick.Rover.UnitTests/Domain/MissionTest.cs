using System;
using System.Collections.Generic;
using Moq;
using Shouldly;
using SkyKick.Rover.Domain;
using SkyKick.Rover.UnitTests.Support;
using Xunit;

namespace SkyKick.Rover.UnitTests.Domain
{
    public class MissionTest
    {

        private static readonly Grid Grid = new Grid(5, 5);

        [Fact]
        public void Constructor_Parameters_Grid_Null_Should_Throw_ArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Mission(default, It.IsAny<Position>(), It.IsAny<MovementPlan>()));
        }

        [Fact]
        public void Constructor_Parameters_Position_Null_Should_Throw_ArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Mission(It.IsAny<Grid>(), default, It.IsAny<MovementPlan>()));
        }

        [Fact]
        public void Constructor_Parameters_MovementPlan_Null_Should_Throw_ArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Mission(It.IsAny<Grid>(), It.IsAny<Position>(), default));
        }

        [Theory, AutoMoqData]
        public void Constructor_Parameters_Valid_Should_Set_Properties(Grid grid, Position startingPosition, MovementPlan movementPlan)
        {
            // Act
            var mission = new Mission(grid, startingPosition, movementPlan);

            // Assert
            mission.Grid.ShouldBe(grid);
            mission.Position.ShouldBe(startingPosition);
            mission.MovementPlan.ShouldBe(movementPlan);
        }

        [Fact]
        public void ProcessCommands_Rover1()
        {
            // Arrange
            const int startingX = 1;
            const int startingY = 2;
            const Orientation startingOrientation = Orientation.N;
            var startingPosition = new Position(startingX, startingY, startingOrientation);

            var movementPlan = new MovementPlan
            {
                Commands = new List<Command>
                {
                    Command.L,
                    Command.M,
                    Command.L,
                    Command.M,
                    Command.L,
                    Command.M,
                    Command.L,
                    Command.M,
                    Command.M
                }
            };

            var mission = new Mission(Grid, startingPosition, movementPlan);

            const int endingX = 1;
            const int endingY = 3;
            const Orientation endingOrientation = Orientation.N;

            // Act
            mission.Process();

            // Assert
            mission.Position.X.ShouldBe(endingX);
            mission.Position.Y.ShouldBe(endingY);
            mission.Position.Orientation.ShouldBe(endingOrientation);
        }
    }
}
