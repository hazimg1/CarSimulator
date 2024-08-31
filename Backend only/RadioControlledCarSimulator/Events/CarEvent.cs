using RadioControlledCarSimulator.Commands.Interfaces;
using RadioControlledCarSimulator.Helpers;

namespace RadioControlledCarSimulator.Events;

/// <summary>
/// Handles car events and outputs results.
/// </summary>
public class CarEvent : ICarEvent
{
    private readonly IIOHelper ioHelper;

    /// <summary>
    /// Initializes a new instance of the <see cref="CarEvent"/> class.
    /// </summary>
    /// <param name="ioHelper">The I/O helper.</param>
    public CarEvent(IIOHelper ioHelper)
    {
        this.ioHelper = ioHelper;
    }

    /// <summary>
    /// Handles the event when the car moves.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    public void CarMoved(object? sender, CarMovedEventArgs e)
    {
        ioHelper.CarProgressOutputResult(e.Success, e.Location, e.Moving, e.Direction);
    }

    /// <summary>
    /// Handles the event when the car turns.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    public void CarTurned(object? sender, CarTurnedEventArgs e)
    {
        ioHelper.CarProgressOutputResult(e.Moving, e.Direction);
    }
}