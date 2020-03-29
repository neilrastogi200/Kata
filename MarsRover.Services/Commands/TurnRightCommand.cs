using MarsRover.Services.Rover;

namespace MarsRover.Services.Commands
{
    public class TurnRightCommand : ICommand
    {
        public void ExecuteCommand(IRover rover)
        {
            rover.TurnRight();
        }
    }
}
