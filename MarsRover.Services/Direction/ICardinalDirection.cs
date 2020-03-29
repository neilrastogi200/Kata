namespace MarsRover.Services.Direction
{
    public interface ICardinalDirection
    {
        ICardinalDirection TurnLeft();
        ICardinalDirection TurnRight();
        bool MoveForward();
        bool MoveBackward();
    }
}
