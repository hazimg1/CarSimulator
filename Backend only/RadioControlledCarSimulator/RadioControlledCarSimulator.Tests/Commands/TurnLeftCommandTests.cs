using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Tests;

public class TurnLeftCommandTests
{
    [Fact]
    public void Execute_ShouldTurnCarLeft()
    {
        var car = new Car(2, 2, Directions.North, new Room(5, 5));
        var command = new TurnLeftCommand(car);

        var result = command.Execute();

        Assert.True(result);
        Assert.Equal(Directions.West, car.Direction);
    }
}
