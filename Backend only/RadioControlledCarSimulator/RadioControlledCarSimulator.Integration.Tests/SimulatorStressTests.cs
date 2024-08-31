using Microsoft.Extensions.Logging;
using Moq;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Integration.Tests;

public class SimulatorStressTests
{
    [Fact]
    public async Task RunAsync_ShouldHandleLargeNumberOfCommands()
    {
        // Arrange
        var ioHelperMock = new Mock<IIOHelper>();
        var commandProcessorMock = new Mock<ICommandProcessor>();
        var loggerMock = new Mock<ILogger<Simulator>>();
        var carEventMock = new Mock<ICarEvent>();
        var simulator = new Simulator(ioHelperMock.Object, commandProcessorMock.Object, loggerMock.Object, carEventMock.Object);

        var room = new Room(100, 100);
        var car = new Car(50, 50, Directions.North, room);
        var commands = new List<ICommand>();

        for (int i = 0; i < 100000; i++)
        {
            commands.Add(new MoveForwardCommand(car));
            commands.Add(new MoveForwardCommand(car));
            commands.Add(new TurnRightCommand(car));
        }

        ioHelperMock.Setup(io => io.GetRoomInputAsync()).ReturnsAsync(room);
        ioHelperMock.Setup(io => io.GetCarInputAsync(room)).ReturnsAsync(car);
        ioHelperMock.Setup(io => io.GetActionCommandsAsync(car)).Returns(GetCommandsAsync(commands));
        commandProcessorMock.Setup(cp => cp.ExecuteCommandsAsync()).ReturnsAsync(true);

        // Act
        await simulator.RunAsync();

        // Assert
        ioHelperMock.Verify(io => io.GetRoomInputAsync(), Times.Once);
        ioHelperMock.Verify(io => io.GetCarInputAsync(room), Times.Once);
        ioHelperMock.Verify(io => io.GetActionCommandsAsync(car), Times.Once);
        commandProcessorMock.Verify(cp => cp.ExecuteCommandsAsync(), Times.Once);
        ioHelperMock.Verify(io => io.OutputResult(true, car), Times.Once);
    }

    private async IAsyncEnumerable<ICommand> GetCommandsAsync(IEnumerable<ICommand> commands)
    {
        foreach (var command in commands)
        {
            yield return command;
            await Task.Yield();
        }
    }
}
