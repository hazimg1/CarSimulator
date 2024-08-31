using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Interfaces;

/// <summary>
/// Validates input data for the simulator.
/// </summary>
public interface IValidator
{
    /// <summary>
    /// Validates the room dimensions input.
    /// </summary>
    /// <param name="input">The input string containing room dimensions.</param>
    /// <returns>A tuple containing the validated room width and height.</returns>
    (int roomWidth, int roomHeight) ValidateRoomDimensions(string? input);

    /// <summary>
    /// Validates the car's starting position input.
    /// </summary>
    /// <param name="input">The input string containing the car's starting position and direction.</param>
    /// <param name="room">The room in which the car is located.</param>
    /// <returns>A tuple containing the validated car's X and Y coordinates and direction.</returns>
    (int carX, int carY, char direction) ValidateCarStartingPosition(string? input, Room room);
}