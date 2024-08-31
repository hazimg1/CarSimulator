using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Tests;

public class TurnRightCommandTests
{
    [Fact]
    public void Execute_ShouldTurnCarRight()
    {
        var car = new Car(2, 2, Directions.North, new Room(5, 5));
        var command = new TurnRightCommand(car);

        var result = command.Execute();

        Assert.True(result);
        Assert.Equal(Directions.East, car.Direction);
    }
}
