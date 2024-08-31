using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Tests;

public class CommandFactoryTests
{
    [Fact]
    public void CreateCommand_ShouldReturnMoveForwardCommand()
    {
        var car = new Car(2, 2, Directions.North, new Room(5, 5));
        var command = CommandFactory.CreateCommand('F', car);

        Assert.IsType<MoveForwardCommand>(command);
    }

    [Fact]
    public void CreateCommand_ShouldReturnMoveBackwardCommand()
    {
        var car = new Car(2, 2, Directions.North, new Room(5, 5));
        var command = CommandFactory.CreateCommand('B', car);

        Assert.IsType<MoveBackwardCommand>(command);
    }

    [Fact]
    public void CreateCommand_ShouldReturnTurnLeftCommand()
    {
        var car = new Car(2, 2, Directions.North, new Room(5, 5));
        var command = CommandFactory.CreateCommand('L', car);

        Assert.IsType<TurnLeftCommand>(command);
    }

    [Fact]
    public void CreateCommand_ShouldReturnTurnRightCommand()
    {
        var car = new Car(2, 2, Directions.North, new Room(5, 5));
        var command = CommandFactory.CreateCommand('R', car);

        Assert.IsType<TurnRightCommand>(command);
    }

    [Fact]
    public void CreateCommand_ShouldReturnNullForInvalidCommand()
    {
        var car = new Car(2, 2, Directions.North, new Room(5, 5));
        var command = CommandFactory.CreateCommand('X', car);

        Assert.Null(command);
    }
}