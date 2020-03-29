using MarsRover.Services.Grid;

namespace MarsRover.Services.Direction
{
    public class West : ICardinalDirection
    {
        private readonly IGrid _grid;

        public West(IGrid grid)
        {
            _grid = grid;
        }

        public ICardinalDirection TurnLeft()
        {
            return new South(_grid);
        }

        public ICardinalDirection TurnRight()
        {
            return new North(_grid);
        }

        public bool MoveForward()
        {
           return _grid.DecreaseBackwardPositionX();
        }

        public bool MoveBackward()
        {
          return _grid.IncreaseForwardPositionX();
        }

        public override string ToString()
        {
            return "West";
        }
    }
}