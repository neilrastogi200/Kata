using MarsRover.Services.Commands;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class CommandParserTests
    {
        private ICommandList _commandList;
            
       [SetUp]
        public void Setup()
        { 
            _commandList = new CommandList();
        }

        [Test]
        public void Get_Correct_Command_To_Move_Forward()
        {
            var commandParser = new CommandParser(_commandList);
            var command = commandParser.ParseCommand("M");
            Assert.That(command, Is.TypeOf<MoveForwardCommand>());
        }

        [Test]
        public void Get_Correct_Command_To_Turn_Left()
        {
            var commandParser = new CommandParser(_commandList);
            var command = commandParser.ParseCommand("L");
            Assert.That(command, Is.TypeOf<TurnLeftCommand>());
        }

        [Test]
        public void Get_Correct_Command_To_Turn_Right()
        {
            var commandParser = new CommandParser(_commandList);
            var command = commandParser.ParseCommand("R");
            Assert.That(command, Is.TypeOf<TurnRightCommand>());
        }

        [Test]
        public void Get_NullCommand_With_Invalid_Command()
        {
            var commandParser = new CommandParser(_commandList);
            var command = commandParser.ParseCommand("G");
            Assert.IsNull(command);
        }
    }
}
