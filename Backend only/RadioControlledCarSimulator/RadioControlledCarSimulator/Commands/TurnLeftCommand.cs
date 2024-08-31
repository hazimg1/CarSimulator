using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;

/// <summary>
/// Command to turn the car left.
/// </summary>
public class TurnLeftCommand : ICommand
{
    private Car car;

    /// <summary>
    /// Initializes a new instance of the <see cref="TurnLeftCommand"/> class.
    /// </summary>
    /// <param name="car">The car to control.</param>
    public TurnLeftCommand(Car car) => this.car = car;

    /// <summary>
    /// Executes the command to turn the car left.
    /// </summary>
    /// <returns>True if the car turned successfully; otherwise, false.</returns>
    public bool Execute()
    {
        car.TurnLeft();
        return true;
    }
}
