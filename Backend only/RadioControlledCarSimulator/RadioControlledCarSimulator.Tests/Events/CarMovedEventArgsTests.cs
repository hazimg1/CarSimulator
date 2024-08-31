using RadioControlledCarSimulator.Events;
using RadioControlledCarSimulator.Models;
using System.Drawing;

namespace RadioControlledCarSimulator.Tests;

public class CarMovedEventArgsTests
{
    [Fact]
    public void CarMovedEventArgs_ShouldInitializeCorrectly()
    {
        var eventArgs = new CarMovedEventArgs(2, 2, Moving.Forward, Directions.North, true);

        Assert.Equal(new Point(2, 2), eventArgs.Location);
        Assert.Equal(Directions.North, eventArgs.Direction);
        Assert.Equal(Moving.Forward, eventArgs.Moving);
        Assert.True(eventArgs.Success);
    }
}
