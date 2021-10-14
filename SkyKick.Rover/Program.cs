using System;
using SkyKick.Rover.Domain;

namespace SkyKick.Rover.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputHelper = new InputHelper();
            Grid grid;

            // Collect user input to define the size of mission grid
            try
            {
                Console.Write("Enter Graph Upper Right Coordinate: ");
                var gridSizeInput = Console.ReadLine();

                // Create the grid, assuming valid input. Leading and trailing spaces are ignored.
                grid = inputHelper.CreateGrid(gridSizeInput);
            }
            catch
            {
                //TODO: Add better exception handling and messaging to user
                Console.WriteLine("Grid size is invalid--mission cannot proceed");
                throw;
            }

            // Collect user input for Rover 1 and execute the mission
            try
            {
                // Create the position, assuming valid input. Leading and trailing spaces are ignored, as is inconsistent casing.
                Console.Write("Rover 1 Starting Position: ");
                var rover1StartingPositionInput = Console.ReadLine();
                var rover1StartingPosition = inputHelper.CreatePosition(rover1StartingPositionInput);

                // Create the movement plan, assuming valid input. Leading and trailing spaces are ignored, as is inconsistent casing.
                Console.Write("Rover 1 Movement Plan: ");
                var rover1MovementPlanInput = Console.ReadLine();
                var rover1MovementPlan = inputHelper.CreateMovementPlan(rover1MovementPlanInput);

                // Create and process the new mission given the requested grid, starting position, and movement plan.
                var rover1Mission = new Mission(grid, rover1StartingPosition, rover1MovementPlan);
                rover1Mission.Process();

                // Capture the rover's ending position
                var rover1EndingPosition = rover1Mission.Position;

                // Display the rover's ending position to the user
                Console.WriteLine($"Rover 1 Output: {rover1EndingPosition}");
            }
            catch
            {
                //TODO: Add better exception handling and messaging to user
                Console.WriteLine("Rover 1 mission failed");
            }

            // Collect user input for Rover 2 and execute the mission
            try
            {
                // Create the position, assuming valid input. Leading and trailing spaces are ignored, as is inconsistent casing.
                Console.Write("Rover 2 Starting Position: ");
                var rover2StartingPositionInput = Console.ReadLine();
                var rover2StartingPosition = inputHelper.CreatePosition(rover2StartingPositionInput);

                // Create the movement plan, assuming valid input. Leading and trailing spaces are ignored, as is inconsistent casing.
                Console.Write("Rover 2 Movement Plan: ");
                var rover2MovementPlanInput = Console.ReadLine();
                var rover2MovementPlan = inputHelper.CreateMovementPlan(rover2MovementPlanInput);

                // Create and process the new mission given the requested grid, starting position, and movement plan.
                var rover2Mission = new Mission(grid, rover2StartingPosition, rover2MovementPlan);
                rover2Mission.Process();

                // Capture the rover's ending position
                var rover2EndingPosition = rover2Mission.Position;

                // Display the rover's ending position to the user
                Console.WriteLine($"Rover 2 Output: {rover2EndingPosition}");
            }
            catch
            {
                //TODO: Add better exception handling and messaging to user
                Console.WriteLine("Rover 2 mission failed");
            }
        }
    }
}
