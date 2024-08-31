using RadioControlledCarSimulator.Events;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Tests;

public class CarTurnedEventArgsTests
{
    [Fact]
    public void CarTurnedEventArgs_ShouldInitializeCorrectly()
    {
        var eventArgs = new CarTurnedEventArgs(Directions.North, Moving.Left);

        Assert.Equal(Directions.North, eventArgs.Direction);
        Assert.Equal(Moving.Left, eventArgs.Moving);
    }
}
