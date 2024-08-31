using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Tests;

public class MoveBackwardCommandTests
{
    [Fact]
    public void Execute_ShouldMoveCarBackward()
    {
        var car = new Car(2, 2, Directions.North, new Room(5, 5));
        var command = new MoveBackwardCommand(car);

        var result = command.Execute();

        Assert.True(result);
        Assert.Equal(2, car.X);
        Assert.Equal(3, car.Y);
    }
}
