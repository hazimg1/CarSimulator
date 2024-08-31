using RadioControlledCarSimulator.Events;

namespace RadioControlledCarSimulator.Models;

/// <summary>
/// Represents a car in the simulator.
/// </summary>
public class Car
{
    public event EventHandler<CarMovedEventArgs>? CarMoved;
    public event EventHandler<CarTurnedEventArgs>? CarTurned;
    public int X { get; private set; }
    public int Y { get; private set; }
    public Directions Direction { get; private set; }
    private readonly Room room;

    /// <summary>
    /// Initializes a new instance of the <see cref="Car"/> class.
    /// </summary>
    /// <param name="x">The initial X coordinate of the car.</param>
    /// <param name="y">The initial Y coordinate of the car.</param>
    /// <param name="direction">The initial direction the car is facing.</param>
    /// <param name="room">The room in which the car is located.</param>
    public Car(int x, int y, Directions direction, Room room)
    {
        X = x;
        Y = y;
        Direction = direction;
        this.room = room;
    }

    /// <summary>
    /// Moves the car forward.
    /// </summary>
    /// <returns>True if the car moved successfully; otherwise, false.</returns>
    public bool MoveForward()
    {
        (X, Y) = Direction switch
        {
            Directions.North => (X, Y - 1),
            Directions.East => (X + 1, Y),
            Directions.South => (X, Y + 1),
            Directions.West => (X - 1, Y),
            _ => (X, Y)
        };

        bool success = IsWithinBounds();
        CarMoved?.Invoke(this, new CarMovedEventArgs(X, Y, Moving.Forward, Direction, success));
        return success;
    }

    /// <summary>
    /// Moves the car backward.
    /// </summary>
    /// <returns>True if the car moved successfully; otherwise, false.</returns>
    public bool MoveBackward()
    {
        (X, Y) = Direction switch
        {
            Directions.North => (X, Y + 1),
            Directions.East => (X - 1, Y),
            Directions.South => (X, Y - 1),
            Directions.West => (X + 1, Y),
            _ => (X, Y)
        };

        bool success = IsWithinBounds();
        CarMoved?.Invoke(this, new CarMovedEventArgs(X, Y, Moving.Backward, Direction, success));
        return success;
    }

    /// <summary>
    /// Turns the car left.
    /// </summary>
    public void TurnLeft()
    {
        Direction = Direction switch
        {
            Directions.North => Directions.West,
            Directions.East => Directions.North,
            Directions.South => Directions.East,
            Directions.West => Directions.South,
            _ => Direction
        };

        CarTurned?.Invoke(this, new CarTurnedEventArgs(Direction, Moving.Left));
    }

    /// <summary>
    /// Turns the car right.
    /// </summary>
    public void TurnRight()
    {
        Direction = Direction switch
        {
            Directions.North => Directions.East,
            Directions.East => Directions.South,
            Directions.South => Directions.West,
            Directions.West => Directions.North,
            _ => Direction
        };

        CarTurned?.Invoke(this, new CarTurnedEventArgs(Direction, Moving.Right));
    }

    /// <summary>
    /// Checks if the car is within the bounds of the room.
    /// </summary>
    /// <returns>True if the car is within bounds; otherwise, false.</returns>
    private bool IsWithinBounds() => X > 0 && X < room.Width && Y > 0 && Y < room.Height;
}
