using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using System.Globalization;


namespace RadioControlledCarSimulator.Commands;

/// <summary>
/// Factory for creating commands.
/// </summary>
public static class CommandFactory
{
    /// <summary>
    /// Creates a command based on the command type and car.
    /// </summary>
    /// <param name="commandType">The type of command to create.</param>
    /// <param name="car">The car to control.</param>
    /// <returns>The created command, or null if the command type is invalid.</returns>
    public static ICommand? CreateCommand(char commandType, Car car) =>
        char.ToUpper(commandType, CultureInfo.CurrentCulture) switch
        {
            'F' => new MoveForwardCommand(car),
            'B' => new MoveBackwardCommand(car),
            'L' => new TurnLeftCommand(car),
            'R' => new TurnRightCommand(car),
            _ => null
        };
}
