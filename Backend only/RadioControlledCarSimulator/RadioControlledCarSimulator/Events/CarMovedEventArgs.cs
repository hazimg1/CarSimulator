using RadioControlledCarSimulator.Models;
using System.Drawing;

namespace RadioControlledCarSimulator.Events;

/// <summary>
/// Provides data for the CarMoved event.
/// </summary>
public class CarMovedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the location of the car.
    /// </summary>
    public Point Location { get; init; }

    /// <summary>
    /// Gets the direction the car is facing.
    /// </summary>
    public Directions Direction { get; init; }

    /// <summary>
    /// Gets the movement direction of the car.
    /// </summary>
    public Moving Moving { get; init; }

    /// <summary>
    /// Gets a value indicating whether the move was successful.
    /// </summary>
    public bool Success { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CarMovedEventArgs"/> class.
    /// </summary>
    /// <param name="x">The X coordinate of the car.</param>
    /// <param name="y">The Y coordinate of the car.</param>
    /// <param name="moving">The movement direction of the car.</param>
    /// <param name="direction">The direction the car is facing.</param>
    /// <param name="success">Indicates whether the move was successful.</param>
    public CarMovedEventArgs(int x, int y, Moving moving, Directions direction, bool success)
    {
        Location = new Point(x, y);
        Direction = direction;
        Moving = moving;
        Success = success;
    }
}