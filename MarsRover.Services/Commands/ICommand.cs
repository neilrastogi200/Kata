using MarsRover.Services.Rover;

namespace MarsRover.Services.Commands
{
    public interface ICommand
    {
        void ExecuteCommand(IRover rover);
    }
}
