using MarsRover.Services.Commands;
using MarsRover.Services.Direction;
using MarsRover.Services.Grid;

namespace MarsRover.Services.Rover
{
    public class Rover : IRover
    {
        private readonly IGrid _grid;
        private readonly ICommandList _commandList;
       
        public Rover(IGrid grid, ICommandList commandList)
        {
            _grid = grid;
            _commandList = commandList;
            Direction = new North(_grid);
        }

        public ICardinalDirection Direction { get; set; }

        public int CoordinateX => _grid.CoordinateX;

        public int CoordinateY => _grid.CoordinateY;

        public void TurnLeft()
        {
            Direction = Direction.TurnLeft();
        }

        public void TurnRight()
        {
           Direction = Direction.TurnRight();
        }

        public bool Forward()
        {
            return Direction.MoveForward();
        }

        public bool Backward()
        {
            return Direction.MoveBackward();
        }

        public ICardinalDirection SetDirection(ICardinalDirection direction)
        {
            Direction = direction;
            return Direction;
        }

        public override string ToString()
        {
            return $"X : {CoordinateX}, Y : {CoordinateY}, Direction : {Direction}";
        }

        public string ExecuteCommands(string command)
        {
            var commandParser = new CommandParser(_commandList);

            for (var index = 0; index < command.Length; index++)
            {
                var commanditem = command[index].ToString();
                var commandToExecute = commandParser.ParseCommand(commanditem);
                commandToExecute?.ExecuteCommand(this);
            }

            return null;
        }
    }
}