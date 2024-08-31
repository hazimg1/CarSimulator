using Moq;
using RadioControlledCarSimulator.Events;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using System.Drawing;

namespace RadioControlledCarSimulator.Tests;

public class CarEventTests
{
    [Fact]
    public void CarMoved_ShouldCallCarProgressOutputResult()
    {
        var ioHelperMock = new Mock<IIOHelper>();
        var carEvent = new CarEvent(ioHelperMock.Object);
        var eventArgs = new CarMovedEventArgs(2, 2, Moving.Forward, Directions.North, true);

        carEvent.CarMoved(null, eventArgs);

        ioHelperMock.Verify(io => io.CarProgressOutputResult(true, new Point(2, 2), Moving.Forward, Directions.North), Times.Once);
    }

    [Fact]
    public void CarTurned_ShouldCallCarProgressOutputResult()
    {
        var ioHelperMock = new Mock<IIOHelper>();
        var carEvent = new CarEvent(ioHelperMock.Object);
        var eventArgs = new CarTurnedEventArgs(Directions.North, Moving.Left);

        carEvent.CarTurned(null, eventArgs);

        ioHelperMock.Verify(io => io.CarProgressOutputResult(Moving.Left, Directions.North), Times.Once);
    }
}
