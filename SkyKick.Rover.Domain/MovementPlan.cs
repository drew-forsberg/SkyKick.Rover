using System.Collections.Generic;

namespace SkyKick.Rover.Domain
{

    // Contains all data for a movement plan, currently consisting of a list of Left (L), Right (R), or Move (M) commands.
    public class MovementPlan
    {
        public List<Command> Commands { get; set; } = new List<Command>();
    }
}
