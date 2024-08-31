using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Tests;

public class RoomTests
{
    [Fact]
    public void Room_ShouldInitializeCorrectly()
    {
        // Arrange & Act
        var room = new Room(5, 5);

        // Assert
        Assert.Equal(5, room.Width);
        Assert.Equal(5, room.Height);
    }

    [Fact]
    public void Room_ShouldThrowExceptionForZeroDimensions()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Room(0, 5));
        Assert.Throws<ArgumentException>(() => new Room(5, 0));
    }

    [Fact]
    public void Room_ShouldInitializeCorrectlyForLargeDimensions()
    {
        // Arrange & Act
        var room = new Room(1000, 1000);

        // Assert
        Assert.Equal(1000, room.Width);
        Assert.Equal(1000, room.Height);
    }

    [Fact]
    public void Room_ShouldThrowExceptionForNegativeDimensions()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Room(-10, 5));
        Assert.Throws<ArgumentException>(() => new Room(5, -10));
    }
}
