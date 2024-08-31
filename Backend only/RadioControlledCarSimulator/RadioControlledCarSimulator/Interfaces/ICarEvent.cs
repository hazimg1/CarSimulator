namespace RadioControlledCarSimulator.Commands.Interfaces;

/// <summary>
/// Defines methods for handling car events.
/// </summary>
public interface ICarEvent
{
    /// <summary>
    /// Handles the event when the car moves.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    void CarMoved(object? sender, Events.CarMovedEventArgs e);

    /// <summary>
    /// Handles the event when the car turns.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    void CarTurned(object? sender, Events.CarTurnedEventArgs e);
}
