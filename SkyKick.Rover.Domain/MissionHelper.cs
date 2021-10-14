using System;

namespace SkyKick.Rover.Domain
{
    /// <summary>
    /// Contains detailed logic that processes a Left (L), Right (R), or Move (M) command on a given position in a grid.
    /// </summary>
    public class MissionHelper
    {
        private const int MoveCount = 1;

        /// <summary>
        /// Rotates the orientation to the left for a given position and starting orientation
        /// </summary>
        public void RotateLeft(Position position)
        {
            var startingOrientation = position.Orientation;
            var endingOrientation = Orientation.Unknown;

            switch (startingOrientation)
            {
                case Orientation.N:
                    endingOrientation = Orientation.W;
                    break;
                case Orientation.E:
                    endingOrientation = Orientation.N;
                    break;
                case Orientation.S:
                    endingOrientation = Orientation.E;
                    break;
                case Orientation.W:
                    endingOrientation = Orientation.S;
                    break;
            }

            position.Orientation = endingOrientation;
        }

        /// <summary>
        /// Rotates the orientation to the right for a given position and starting orientation
        /// </summary>
        public void RotateRight(Position position)
        {
            var startingOrientation = position.Orientation;
            var endingOrientation = Orientation.Unknown;

            switch (startingOrientation)
            {
                case Orientation.N:
                    endingOrientation = Orientation.E;
                    break;
                case Orientation.E:
                    endingOrientation = Orientation.S;
                    break;
                case Orientation.S:
                    endingOrientation = Orientation.W;
                    break;
                case Orientation.W:
                    endingOrientation = Orientation.N;
                    break;
            }

            position.Orientation = endingOrientation;
        }

        /// <summary>
        /// Advances the position given starting X + Y location and orientation
        /// </summary>
        public void Move(Grid grid, Position position)
        {
            var endingX = position.X;
            var endingY = position.Y;

            switch (position.Orientation)
            {
                case Orientation.N:
                    endingY = position.Y + MoveCount;
                    break;
                case Orientation.E:
                    endingX = position.X + MoveCount;
                    break;
                case Orientation.S:
                    endingY = position.Y - MoveCount;
                    break;
                case Orientation.W:
                    endingX = position.X - MoveCount;
                    break;
            }

            if (endingX < 0 || endingX > grid.X)
            {
                throw new ArgumentOutOfRangeException(nameof(position),"Moves exceed the horizontal limit of the current grid");
            }

            if (endingY < 0 || endingY > grid.Y)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Moves exceed the vertical limit of the current grid");
            }

            position.X = endingX;
            position.Y = endingY;
        }
    }
}
