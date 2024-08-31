using Moq;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Interfaces;

namespace RadioControlledCarSimulator.Tests;

public class CommandProcessorTests
{
    [Fact]
    public async Task AddCommandAsync_ShouldAddCommand()
    {
        var commandProcessor = new CommandProcessor();
        var commandMock = new Mock<ICommand>();
        commandMock.Setup(c => c.Execute()).Returns(true);
        await commandProcessor.AddCommandAsync(commandMock.Object);

        var result = await commandProcessor.ExecuteCommandsAsync();

        Assert.True(result);
        commandMock.Verify(c => c.Execute(), Times.Once);
    }

    [Fact]
    public async Task ExecuteCommandsAsync_ShouldReturnFalseIfAnyCommandFails()
    {
        var commandProcessor = new CommandProcessor();
        var commandMock1 = new Mock<ICommand>();
        var commandMock2 = new Mock<ICommand>();

        commandMock1.Setup(c => c.Execute()).Returns(true);
        commandMock2.Setup(c => c.Execute()).Returns(false);

        await commandProcessor.AddCommandAsync(commandMock1.Object);
        await commandProcessor.AddCommandAsync(commandMock2.Object);

        var result = await commandProcessor.ExecuteCommandsAsync();

        Assert.False(result);
    }
}
