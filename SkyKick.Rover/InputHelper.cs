using System;
using System.Text.RegularExpressions;
using SkyKick.Rover.Domain;

namespace SkyKick.Rover.ConsoleApplication
{
    /// <summary>
    /// Provides functionality to validate user input and translate it into objects required to complete a mission.
    /// </summary>
    public class InputHelper
    {
        private const string GridSizePattern = @"^(?<X>\d+)\s(?<Y>\d+)$";
        private static readonly Regex GridSizeRegex = new Regex(GridSizePattern, RegexOptions.Compiled);

        private const string PositionPattern = @"^(?<X>\d+)\s(?<Y>\d+)\s(?<Orientation>[N|E|S|W])$";
        private static readonly Regex PositionRegex = new Regex(PositionPattern, RegexOptions.Compiled);

        private const string MovementPlanPattern = @"^[M|L|R]+$";
        private static readonly Regex MovementPlanRegex = new Regex(MovementPlanPattern, RegexOptions.Compiled);

        /// <summary>
        /// Creates a Grid object from text entered by the user, performing basic input validation.
        /// </summary>
        public Grid CreateGrid(string inputText)
        {
            // Basic validation
            if (inputText == null)
            {
                throw new ArgumentNullException(nameof(inputText));
            }

            // Standardize input formatting
            inputText = inputText.Trim();

            // Attempt to match user input based on the expected pattern
            var match = GridSizeRegex.Match(inputText);

            if (!match.Success)
            {
                throw new ArgumentException($"\"{inputText}\" is not a valid set of grid dimensions", nameof(inputText));
            }

            // Input is valid--we can safely parse it and create and return a Grid 
            var x = int.Parse(match.Groups["X"].Value);
            var y = int.Parse(match.Groups["Y"].Value);

            var grid = new Grid(x, y);

            return grid;
        }

        /// <summary>
        /// Creates a Position object from text entered by the user, performing basic input validation.
        /// </summary>
        public Position CreatePosition(string inputText)
        {
            // Basic validation
            if (inputText == null)
            {
                throw new ArgumentNullException(nameof(inputText));
            }

            // Standardize input formatting
            inputText = inputText.Trim().ToUpper();

            // Attempt to match user input based on the expected pattern
            var match = PositionRegex.Match(inputText.ToUpper());

            if (!match.Success)
            {
                throw new ArgumentException($"\"{inputText}\" is not a valid position", nameof(inputText));
            }

            // Input is valid--we can safely parse it and create and return a Position 
            var x = int.Parse(match.Groups["X"].Value);
            var y = int.Parse(match.Groups["Y"].Value);
            var orientation = (Orientation)Enum.Parse(typeof(Orientation), match.Groups["Orientation"].Value);

            var position = new Position(x, y, orientation);

            return position;
        }

        /// <summary>
        /// Creates a MovementPlan object from text entered by the user, performing basic input validation.
        /// </summary>
        public MovementPlan CreateMovementPlan(string inputText)
        {
            // Basic validation
            if (inputText == null)
            {
                throw new ArgumentNullException(nameof(inputText));
            }

            // Standardize input formatting
            inputText = inputText.Trim().ToUpper();

            // Attempt to match user input based on the expected pattern
            var match = MovementPlanRegex.Match(inputText);

            if (!match.Success)
            {
                throw new ArgumentException($"\"{inputText}\" is not a valid movement plan", nameof(inputText));
            }

            // Input text is valid -- parse it to create a list of commands
            var movementPlan  = new MovementPlan();

            var commandCharacters = inputText.ToCharArray();
            foreach (var character in commandCharacters)
            {
                Command command;

                // Because of the Regex validation above, we know inputText only contains a combination of L, R, or M
                if (character == 'L')
                {
                    command = Command.L;
                }
                else if (character == 'R')
                {
                    command = Command.R;
                }
                else
                {
                    command = Command.M;
                }

                // Add the current command to our running list
                movementPlan.Commands.Add(command);
            }

            return movementPlan;
        }
    }
}
