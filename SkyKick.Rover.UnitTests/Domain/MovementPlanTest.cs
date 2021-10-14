using Shouldly;
using SkyKick.Rover.Domain;
using Xunit;

namespace SkyKick.Rover.UnitTests.Domain
{
    public class MovementPlanTest
    {
        [Fact]
        public void Constructor_Should_Initialize_Commands()
        {
            // Act
            var missionPlan = new MovementPlan();

            // Assert
            missionPlan.Commands.ShouldNotBeNull();
            missionPlan.Commands.ShouldBeEmpty();
        }
    }
}
