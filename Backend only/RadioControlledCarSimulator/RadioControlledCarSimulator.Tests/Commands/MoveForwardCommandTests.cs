using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Tests;

public class MoveForwardCommandTests
{
    [Fact]
    public void Execute_ShouldMoveCarForward()
    {
        var car = new Car(2, 2, Directions.North, new Room(5, 5));
        var command = new MoveForwardCommand(car);

        var result = command.Execute();

        Assert.True(result);
        Assert.Equal(2, car.X);
        Assert.Equal(1, car.Y);
    }
}