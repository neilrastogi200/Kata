using System;

namespace MarsRover.Services.Grid
{
    public class Grid : IGrid
    {
        private readonly int _gridSize;

        public Grid(int gridSize)
        {
            _gridSize = gridSize;
        }

        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }

        public bool IncreaseForwardPositionY()
        {
       
            if (CoordinateY < _gridSize)
            {
                CoordinateY++;

            }
            return true;
        }

        public bool IncreaseForwardPositionX()
        {
            if (CoordinateX < _gridSize)
            {
                CoordinateX++;
                return false;
            }

            return true;
        }

        public bool DecreaseBackwardPositionY()
        {
            if (CoordinateY > 0)
            {
                CoordinateY--;
            }

            return true;
        }

        public bool DecreaseBackwardPositionX()
        {
            if (CoordinateX > 0)
            {
                CoordinateX--;
            }

            return true;
        }
        public void ValidateInputCoordinates(int coordinateX, int coordinateY)
        {
            if (coordinateX > _gridSize || coordinateY > _gridSize)
            {
                throw new ArgumentException();
            }

            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
    }
}