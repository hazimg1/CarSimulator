using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;

/// <summary>
/// Command to move the car backward.
/// </summary>
public class MoveBackwardCommand : ICommand
{
    private Car car;

    /// <summary>
    /// Initializes a new instance of the <see cref="MoveBackwardCommand"/> class.
    /// </summary>
    /// <param name="car">The car to control.</param>
    public MoveBackwardCommand(Car car) => this.car = car;

    /// <summary>
    /// Executes the command to move the car backward.
    /// </summary>
    /// <returns>True if the car moved successfully; otherwise, false.</returns>
    public bool Execute() => car.MoveBackward();
}
