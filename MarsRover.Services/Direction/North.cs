using MarsRover.Services.Grid;

namespace MarsRover.Services.Direction
{
    public class North : ICardinalDirection
    {
        private readonly IGrid _grid;

        public North(IGrid grid)
        {
            _grid = grid;
        }

        public ICardinalDirection TurnLeft()
        {
            return new West(_grid);
        }

        public ICardinalDirection TurnRight()
        {
            return new East(_grid);
        }

        public bool MoveForward()
        {
           return _grid.IncreaseForwardPositionY();
        }

        public bool MoveBackward()
        {
           return _grid.DecreaseBackwardPositionY();
        }

        public override string ToString()
        {
            return "North";
        }
    }
}
