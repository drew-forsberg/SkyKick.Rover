using System;

namespace SkyKick.Rover.Domain
{
    /// <summary>
    /// Encapsulates data and logic needed to process a mission on a given Grid, given the requested starting Position and MovementPlan
    /// </summary>
    public class Mission
    {
        private readonly MissionHelper _missionHelper = new MissionHelper();

        public Grid Grid { get; set; }

        public Position Position { get; set; }

        public MovementPlan MovementPlan { get; set; }

        public Mission(Grid grid, Position startingPosition, MovementPlan movementPlan)
        {
            Grid = grid ?? throw new ArgumentNullException(nameof(grid));
            Position = startingPosition ?? throw new ArgumentNullException(nameof(startingPosition));
            MovementPlan = movementPlan ?? throw new ArgumentNullException(nameof(movementPlan));
        }

        public void Process()
        {
            foreach (var command in MovementPlan.Commands)
            {
                ProcessCommand(command);
            }
        }

        private void ProcessCommand(Command command)
        {
            switch (command)
            {
                case Command.L:
                    _missionHelper.RotateLeft(Position);
                    break;
                case Command.R:
                    _missionHelper.RotateRight(Position);
                    break;

                case Command.M:
                    _missionHelper.Move(Grid, Position);
                    break;
            }
        }
    }
}
