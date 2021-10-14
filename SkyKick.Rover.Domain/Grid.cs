using System;

namespace SkyKick.Rover.Domain
{
    /// <summary>
    /// Represents the orthogonal grid in which a mission will be conducted. X and Y represent the maximum upper-right coordinates.
    /// </summary>
    public class Grid
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Grid(int x, int y)
        {
            // Basic validation. The grid must have a size--negative or 0 values for X and Y are invalid.
            if (x <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            if (y <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }

            X = x;
            Y = y;
        }
    }
}
