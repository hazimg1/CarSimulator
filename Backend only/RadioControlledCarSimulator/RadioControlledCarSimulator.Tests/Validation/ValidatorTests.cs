using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Validation;

namespace RadioControlledCarSimulator.Tests;

public class ValidatorTests
{
    [Fact]
    public void ValidateRoomDimensions_ShouldReturnValidDimensions()
    {
        var validator = new Validator();
        var input = "5 5";

        var result = validator.ValidateRoomDimensions(input);

        Assert.Equal((5, 5), result);
    }

    [Fact]
    public void ValidateRoomDimensions_ShouldThrowExceptionForInvalidInput()
    {
        var validator = new Validator();
        var input = "invalid input";

        Assert.Throws<ArgumentException>(() => validator.ValidateRoomDimensions(input));
    }

    [Fact]
    public void ValidateCarStartingPosition_ShouldReturnValidPosition()
    {
        var validator = new Validator();
        var room = new Room(5, 5);
        var input = "2 2 N";

        var result = validator.ValidateCarStartingPosition(input, room);

        Assert.Equal((2, 2, 'N'), result);
    }

    [Fact]
    public void ValidateCarStartingPosition_ShouldThrowExceptionForInvalidInput()
    {
        var validator = new Validator();
        var room = new Room(5, 5);
        var input = "invalid input";

        Assert.Throws<ArgumentException>(() => validator.ValidateCarStartingPosition(input, room));
    }
}
