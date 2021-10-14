using System;

namespace SkyKick.Rover.Domain
{
    /// <summary>
    /// Represents an X, Y position on an orthogonal grid
    /// </summary>
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientation Orientation { get; set; }

        public Position(int x, int y, Orientation orientation)
        {
            // Basic validation. Negative coordinate values are invalid.
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            if (y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }

            X = x;
            Y = y;
            Orientation = orientation;
        }

        /// <summary>
        /// Returns the Position a string for display using the format "X Y Orientation"
        /// </summary>
        public override string ToString()
        {
            return $"{X} {Y} {Orientation}";
        }
    }
}
