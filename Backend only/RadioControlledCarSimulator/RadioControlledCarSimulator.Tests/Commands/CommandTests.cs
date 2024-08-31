using Moq;
using RadioControlledCarSimulator.Interfaces;

namespace RadioControlledCarSimulator.Tests;

public class CommandTests
{
    [Fact]
    public void Execute_ShouldReturnTrue()
    {
        var commandMock = new Mock<ICommand>();
        commandMock.Setup(c => c.Execute()).Returns(true);

        var result = commandMock.Object.Execute();

        Assert.True(result);
    }

    [Fact]
    public void Execute_ShouldReturnFalse()
    {
        var commandMock = new Mock<ICommand>();
        commandMock.Setup(c => c.Execute()).Returns(false);

        var result = commandMock.Object.Execute();

        Assert.False(result);
    }
}
