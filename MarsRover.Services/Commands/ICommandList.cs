using System.Collections.Generic;

namespace MarsRover.Services.Commands
{
    public interface ICommandList
    {
        Dictionary<string, ICommand> AvailableCommandList { get; }
    }
}