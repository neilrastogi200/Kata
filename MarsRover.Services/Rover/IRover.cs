namespace MarsRover.Services.Rover
{
    public interface IRover
    {
        void TurnLeft();

        void TurnRight();

        bool Forward();

        string ExecuteCommands(string command);

    }
}