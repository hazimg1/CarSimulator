using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;

/// <summary>
/// Command to move the car forward.
/// </summary>
public class MoveForwardCommand : ICommand
{
    private Car car;

    /// <summary>
    /// Initializes a new instance of the <see cref="MoveForwardCommand"/> class.
    /// </summary>
    /// <param name="car">The car to control.</param>
    public MoveForwardCommand(Car car) => this.car = car;

    /// <summary>
    /// Executes the command to move the car forward.
    /// </summary>
    /// <returns>True if the car moved successfully; otherwise, false.</returns>
    public bool Execute() => car.MoveForward();
}