using System;
using MarsRover.Services.Commands;
using MarsRover.Services.Direction;
using MarsRover.Services.Grid;
using MarsRover.Services.Rover;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [SetUp]
        public void Setup()
        {
            _grid = new Grid(5);
            _commandList = new CommandList();
        }

        private IGrid _grid;
     
        private ICommandList _commandList;


        [Test]
        [TestCase("LMLMLMLMM", 1, 2, "North")]
        [TestCase("MMRMMRMRRM", 2, 2, "North")]
        [TestCase("LLRM",0,0,"West")]
        public void ExecuteCommands_With_Multiple_Commands(string commandString, int xCoordinateExpected,
            int yCoordinateExpected, string directionExpected)
        {
            //Arrange
            var rover = new Rover(_grid, _commandList);
            //Act
            rover.ExecuteCommands(commandString);

            //Assert
            Assert.That(rover.CoordinateX, Is.EqualTo(xCoordinateExpected));
            Assert.That(rover.CoordinateY, Is.EqualTo(yCoordinateExpected));
            Assert.That(rover.Direction.ToString(), Is.EqualTo(directionExpected));
        }


        [Test]
        [TestCase(1,1,"East","MLMR",2,2,"East")]
        [TestCase(3,3,"East","R",3,3,"South")]
        public void ExecuteCommands_With_Multiple_Commands2(int x, int y, string inputDirection, string inputcommand,
            int expectedXcoordinate, int expectedYCoordinate, string expectedDirection)
        {
            //Arrange
            ICardinalDirection direction = null;

            switch (inputDirection)
            {
                case "East":
                    direction = new East(_grid);
                    break;
                case "North":
                    direction = new North(_grid);
                    break;
                case "West":
                    direction = new West(_grid);
                    break;
                case "South":
                    direction = new South(_grid);
                    break;
            }

            var rover = new Rover(_grid, _commandList);

            //Act
            _grid.ValidateInputCoordinates(x, y);
            rover.SetDirection(direction);
            rover.ExecuteCommands(inputcommand);
            

            //Assert
            Assert.That(rover.CoordinateX, Is.EqualTo(expectedXcoordinate));
            Assert.That(rover.CoordinateY, Is.EqualTo(expectedYCoordinate));
            Assert.That(rover.Direction.ToString(), Is.EqualTo(expectedDirection));
        }


        [Test]
        public void Given_Position_With_Default_Direction_And_Forward_Command_Returns_0_1_N()
        {
            //Arrange
            var rover = new Rover(_grid, _commandList);
            ICardinalDirection direction = new North(_grid);

            //Act
            rover.SetDirection(direction);
            rover.ExecuteCommands("M");

            //Assert
            Assert.That(rover.CoordinateX, Is.EqualTo(0));
            Assert.That(rover.CoordinateY, Is.EqualTo(1));
            Assert.That(rover.Direction, Is.TypeOf(typeof(North)));
        }

        [Test]
        public void Given_Position_When_Direction_Is_East_And_No_Command_Returns_Null()
        {
            //Arrange
            int x = 3;
            int y = 3;
            string command = "";
            var rover = new Rover(_grid, _commandList);
            ICardinalDirection direction = new East(_grid);

            //Act
            _grid.ValidateInputCoordinates(x,y);
            rover.SetDirection(direction);
            var actualResult = rover.ExecuteCommands(command);

            //Assert
            Assert.AreEqual(actualResult,null);
        }

        [Test]
        public void ValidateInputCoordinates_When_Invalid_Coordinates_Throws_ArgumentException_Error()
        {
            //Arrange
            int x = 10;
            int y = 3;
            
            var rover = new Rover(_grid, _commandList);
         
            //Assert
            Assert.Throws<ArgumentException>(() => _grid.ValidateInputCoordinates(x, y));
        }



        [Test]
        public void When_Rover_Command_Is_Forward_And_TurnRight_The_Direction_Is_East()
        {
            //Arrange
            var rover = new Rover(_grid, _commandList);

            var command = "MR";
            //Act
            rover.ExecuteCommands(command);
            //Assert
            Assert.That(rover.Direction, Is.TypeOf<East>());
            Assert.That(rover.CoordinateX, Is.EqualTo(0));
            Assert.That(rover.CoordinateY, Is.EqualTo(1));
        }


        [Test]
        public void When_Rover_Command_Is_Left_Returns_Direction_Is_West_With_Default_Coordinates()
        {
            //Arrange
            var rover = new Rover(_grid, _commandList);

            var command = "L";

            //Act
            rover.ExecuteCommands(command);
            //Assert
            Assert.That(rover.Direction, Is.TypeOf<West>());
            Assert.That(rover.CoordinateX, Is.EqualTo(0));
            Assert.That(rover.CoordinateY, Is.EqualTo(0));
        }


        [Test]
        public void When_Rover_Command_Is_Right_Returns_Direction_Is_East_With_Default_Coordinates()
        {
            //Arrange
            var rover = new Rover(_grid, _commandList);
            var command = "R";
            //Act
            rover.ExecuteCommands(command);
            //Assert
            Assert.That(rover.Direction, Is.TypeOf<East>());
            Assert.That(rover.CoordinateX, Is.EqualTo(0));
            Assert.That(rover.CoordinateY, Is.EqualTo(0));
        }

        [Test]
        public void When_Rover_Is_Created_And_Turn_Left_The_Direction_Is_West()
        {
            //Arrange
            var rover = new Rover(_grid, _commandList);
            //Act
            rover.TurnLeft();
            //Assert
            Assert.That(rover.Direction, Is.TypeOf<West>());
        }


        [Test]
        public void When_Rover_Is_Created_And_Turn_Right_The_Direction_Is_East()
        {
            //Arrange
            var rover = new Rover(_grid, _commandList);
            //Act
            rover.TurnRight();
            //Assert
            Assert.That(rover.Direction, Is.TypeOf<East>());
        }
    }
}