using MarsRover.Services.Grid;

namespace MarsRover.Services.Direction
{
    public class East : ICardinalDirection
    {
        private readonly IGrid _grid;

        public East(IGrid grid)
        {
            _grid = grid;
        }

        public ICardinalDirection TurnLeft()
        {
            return new North(_grid);
        }

        public ICardinalDirection TurnRight()
        {
            return new South(_grid);
        }

        public bool MoveForward()
        {
            return _grid.IncreaseForwardPositionX();
        }

        public bool MoveBackward()
        {
           return _grid.DecreaseBackwardPositionX();
        }

        public override string ToString()
        {
            return "East";
        }
    }
}