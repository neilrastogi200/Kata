using MarsRover.Services.Rover;

namespace MarsRover.Services.Commands
{
    public class TurnLeftCommand : ICommand
    {
        public void ExecuteCommand(IRover rover)
        {
            rover.TurnLeft();
        }
    }
}
