
using RadioControlledCarSimulator.Models;
namespace RadioControlledCarSimulator.Tests;

public class CarTests
{
    #region Turn Left
    [Fact]
    public void TurnLeft_ShouldUpdateDirection_From_North_To_West()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(2, 2, Directions.North, room);

        // Act
        car.TurnLeft();

        // Assert
        Assert.Equal(Directions.West, car.Direction);
    }

    [Fact]
    public void TurnLeft_ShouldUpdateDirection_From_West_To_South()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(2, 2, Directions.West, room);

        // Act
        car.TurnLeft();

        // Assert
        Assert.Equal(Directions.South, car.Direction);
    }

    [Fact]
    public void TurnLeft_ShouldUpdateDirection_From_South_To_East()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(2, 2, Directions.South, room);

        // Act
        car.TurnLeft();

        // Assert
        Assert.Equal(Directions.East, car.Direction);
    }

    [Fact]
    public void TurnLeft_ShouldUpdateDirection_From_East_To_North()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(2, 2, Directions.East, room);

        // Act
        car.TurnLeft();

        // Assert
        Assert.Equal(Directions.North, car.Direction);
    }
    #endregion

    #region Turn Right
    [Fact]
    public void TurnRight_ShouldUpdateDirection_From_North_to_East()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(2, 2, Directions.North, room);

        // Act
        car.TurnRight();

        // Assert
        Assert.Equal(Directions.East, car.Direction);
    }

    [Fact]
    public void TurnRight_ShouldUpdateDirection_From_East_to_South()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(2, 2, Directions.East, room);

        // Act
        car.TurnRight();

        // Assert
        Assert.Equal(Directions.South, car.Direction);
    }

    [Fact]
    public void TurnRight_ShouldUpdateDirection_From_South_To_West()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(2, 2, Directions.South, room);

        // Act
        car.TurnRight();

        // Assert
        Assert.Equal(Directions.West, car.Direction);
    }

    [Fact]
    public void TurnRight_ShouldUpdateDirection_From_West_To_north()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(2, 2, Directions.West, room);

        // Act
        car.TurnRight();

        // Assert
        Assert.Equal(Directions.North, car.Direction);
    }
    #endregion

    #region Move Forward
    [Fact]
    public void MoveForward_ShouldUpdatePosition()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(2, 2, Directions.North, room);

        // Act
        var result = car.MoveForward();

        // Assert
        Assert.True(result);
        Assert.Equal(2, car.X);
        Assert.Equal(1, car.Y);
        Assert.Equal(Directions.North, car.Direction);
    }

    [Fact]
    public void MoveForward_ShouldFailWhenHittingNorthWall()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(3, 1, Directions.North, room);

        // Act
        var result = car.MoveForward();

        // Assert
        Assert.False(result);
        Assert.Equal(Directions.North, car.Direction);
        Assert.Equal(3, car.X);
        Assert.Equal(0, car.Y);
    }

    [Fact]
    public void MoveForward_ShouldFailWhenHittingEastWall()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(4, 1, Directions.East, room);

        // Act
        var result = car.MoveForward();

        // Assert
        Assert.False(result);
        Assert.Equal(Directions.East, car.Direction);
        Assert.Equal(5, car.X);
        Assert.Equal(1, car.Y);
    }

    [Fact]
    public void MoveForward_ShouldFailWhenHittingSouthWall()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(3, 4, Directions.South, room);

        // Act
        var result = car.MoveForward();

        // Assert
        Assert.False(result);
        Assert.Equal(Directions.South, car.Direction);
        Assert.Equal(3, car.X);
        Assert.Equal(5, car.Y);
    }

    [Fact]
    public void MoveForward_ShouldFailWhenHittingWestWall()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(1, 3, Directions.West, room);

        // Act
        var result = car.MoveForward();

        // Assert
        Assert.False(result);
        Assert.Equal(Directions.West, car.Direction);
        Assert.Equal(0, car.X);
        Assert.Equal(3, car.Y);
    }

    [Fact]
    public void MoveForward_MultipleSteps_ShouldUpdatePosition()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(3, 3, Directions.North, room);

        // Act
        var result1 = car.MoveForward();
        var result2 = car.MoveForward();

        // Assert
        Assert.True(result1);
        Assert.True(result2);
        Assert.Equal(3, car.X);
        Assert.Equal(1, car.Y);
    }

    #endregion

    #region Move Backward
    [Fact]
    public void MoveBackward_ShouldUpdatePosition()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(2, 2, Directions.North, room);

        // Act
        var result = car.MoveBackward();

        // Assert
        Assert.True(result);
        Assert.Equal(2, car.X);
        Assert.Equal(3, car.Y);
        Assert.Equal(Directions.North, car.Direction);
    }

    [Fact]
    public void MoveBackward_ShouldFailWhenHittingNorthWall()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(3, 4, Directions.North, room);

        // Act
        var result = car.MoveBackward();

        // Assert
        Assert.False(result);
        Assert.Equal(Directions.North, car.Direction);
        Assert.Equal(3, car.X);
        Assert.Equal(5, car.Y);
    }

    [Fact]
    public void MoveBackward_ShouldFailWhenHittingEastWall()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(1, 1, Directions.East, room);

        // Act
        var result = car.MoveBackward();

        // Assert
        Assert.False(result);
        Assert.Equal(Directions.East, car.Direction);
        Assert.Equal(0, car.X);
        Assert.Equal(1, car.Y);
    }

    [Fact]
    public void MoveBackward_ShouldFailWhenHittingSouthWall()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(3, 1, Directions.South, room);

        // Act
        var result = car.MoveBackward();

        // Assert
        Assert.False(result);
        Assert.Equal(Directions.South, car.Direction);
        Assert.Equal(3, car.X);
        Assert.Equal(0, car.Y);
    }

    [Fact]
    public void MoveBackward_ShouldFailWhenHittingWestWall()
    {
        // Arrange
        var room = new Room(5, 5);
        var car = new Car(4, 3, Directions.West, room);

        // Act
        var result = car.MoveBackward();

        // Assert
        Assert.False(result);
        Assert.Equal(Directions.West, car.Direction);
        Assert.Equal(5, car.X);
        Assert.Equal(3, car.Y);
    }
    #endregion

}