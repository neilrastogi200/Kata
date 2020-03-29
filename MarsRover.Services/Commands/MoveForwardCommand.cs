using MarsRover.Services.Rover;

namespace MarsRover.Services.Commands
{
    public class MoveForwardCommand : ICommand
    {
        public void ExecuteCommand(IRover rover)
        {
            rover.Forward();
        }
    }
}
