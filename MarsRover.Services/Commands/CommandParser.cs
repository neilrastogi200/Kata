namespace MarsRover.Services.Commands
{
    public class CommandParser
    {
        private readonly ICommandList _commandList;

        public CommandParser(ICommandList commandList)
        {
            _commandList = commandList;
        }

        public ICommand ParseCommand(string command)
        {
            if (_commandList.AvailableCommandList.ContainsKey(command))
            {
                return _commandList.AvailableCommandList[command];
            }

            return null;
        }
    }
}
