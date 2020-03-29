using System.Collections.Generic;

namespace MarsRover.Services.Commands
{
    public class CommandList : ICommandList
    {
        public Dictionary<string, ICommand> AvailableCommandList
        {
            get
            {
                var commands = new Dictionary<string, ICommand>
                    {
                    { "M", new MoveForwardCommand()},
                    { "L", new TurnLeftCommand()},
                    { "R", new TurnRightCommand()}
                };
                return commands;
            }
        }

      
    }
}
