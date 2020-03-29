using MarsRover.Services.Grid;

namespace MarsRover.Services.Direction
{
    public class South : ICardinalDirection
    {
        private readonly IGrid _grid;

        public South(IGrid grid)
        {
            _grid = grid;
        }

        public ICardinalDirection TurnLeft()
        {
            return new East(_grid);
        }

        public ICardinalDirection TurnRight()
        {
            return new West(_grid);
        }

        public bool MoveForward()
        {
           return _grid.DecreaseBackwardPositionY();
        }

        public bool MoveBackward()
        {
          return _grid.IncreaseForwardPositionY();
        }

        public override string ToString()
        {
            return "South";
        }
    }
}