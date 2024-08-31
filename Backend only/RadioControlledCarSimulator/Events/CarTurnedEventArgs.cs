using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Events;

/// <summary>
/// Provides data for the CarTurned event.
/// </summary>
public class CarTurnedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the direction the car is facing.
    /// </summary>
    public Directions Direction { get; init; }

    /// <summary>
    /// Gets the movement direction of the car.
    /// </summary>
    public Moving Moving { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CarTurnedEventArgs"/> class.
    /// </summary>
    /// <param name="direction">The direction the car is facing.</param>
    /// <param name="moving">The movement direction of the car.</param>
    public CarTurnedEventArgs(Directions direction, Moving moving)
    {
        Moving = moving;
        Direction = direction;
    }
}