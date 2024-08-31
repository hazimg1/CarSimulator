using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;

/// <summary>
/// Command to turn the car right.
/// </summary>
public class TurnRightCommand : ICommand
{
    private Car car;

    /// <summary>
    /// Initializes a new instance of the <see cref="TurnRightCommand"/> class.
    /// </summary>
    /// <param name="car">The car to control.</param>
    public TurnRightCommand(Car car) => this.car = car;

    /// <summary>
    /// Executes the command to turn the car right.
    /// </summary>
    /// <returns>True if the car turned successfully; otherwise, false.</returns>
    public bool Execute()
    {
        car.TurnRight();
        return true;
    }
}
