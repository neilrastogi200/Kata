namespace MarsRover.Services.Grid
{
    public interface IGrid
    {
        int CoordinateX { get; }
        int CoordinateY { get; }
        bool IncreaseForwardPositionY();
        bool IncreaseForwardPositionX();
        bool DecreaseBackwardPositionY();
        bool DecreaseBackwardPositionX();
        void ValidateInputCoordinates(int x, int y);

    }
}
