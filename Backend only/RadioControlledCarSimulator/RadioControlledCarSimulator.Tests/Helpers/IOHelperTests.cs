using Moq;
using RadioControlledCarSimulator.Helpers;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using System.Drawing;

namespace RadioControlledCarSimulator.Tests;

public class IOHelperTests
{
    [Fact]
    public void CarProgressOutputResult_ShouldOutputCorrectMessage()
    {
        var validatorMock = new Mock<IValidator>();
        var ioHelper = new IOHelper(validatorMock.Object);
        var location = new Point(2, 2);

        using var writer = new StringWriter();
        Console.SetOut(writer);

        ioHelper.CarProgressOutputResult(true, location, Moving.Forward, Directions.North);

        var output = writer.ToString().Trim();
        Assert.Equal("Car is moved Forward to position: (2, 2) facing North", output);
    }

    [Fact]
    public async Task GetRoomInputAsync_ShouldReturnValidRoom()
    {
        var validatorMock = new Mock<IValidator>();
        validatorMock.Setup(v => v.ValidateRoomDimensions(It.IsAny<string>())).Returns((5, 5));
        var ioHelper = new IOHelper(validatorMock.Object);

        using var reader = new StringReader("5 5");
        Console.SetIn(reader);

        var room = await ioHelper.GetRoomInputAsync();

        Assert.Equal(5, room.Width);
        Assert.Equal(5, room.Height);
    }

    [Fact]
    public void OutputResult_ShouldOutputCorrectMessage()
    {
        var validatorMock = new Mock<IValidator>();
        var ioHelper = new IOHelper(validatorMock.Object);
        var car = new Car(2, 2, Directions.North, new Room(5, 5));

        using var writer = new StringWriter();
        Console.SetOut(writer);

        ioHelper.OutputResult(true, car);

        var output = writer.ToString().Trim();
        Assert.Equal("Success! Final position: (2, 2) facing North", output);
    }
}
