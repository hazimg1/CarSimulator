using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Validation;

/// <summary>
/// Validates input data for the simulator.
/// </summary>
public class Validator : IValidator
{
    private const string AllDirections = "EeWwNnSs";

    /// <summary>
    /// Validates the room dimensions input.
    /// </summary>
    /// <param name="input">The input string containing room dimensions.</param>
    /// <returns>A tuple containing the validated room width and height.</returns>
    public (int roomWidth, int roomHeight) ValidateRoomDimensions(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("Input cannot be empty. Please enter room dimensions.");
        }

        var roomDimensions = input.Split(' ');
        if (roomDimensions.Length != 2)
        {
            throw new ArgumentException("Invalid room dimensions input. Please enter two integers separated by a space.");
        }

        if (!int.TryParse(roomDimensions[0], out int roomWidth) || roomWidth < 2)
        {
            throw new ArgumentException("Invalid room width. Please enter a positive integer greater than 1 to accommodate the car (1 x 1).");
        }

        if (!int.TryParse(roomDimensions[1], out int roomHeight) || roomHeight < 2)
        {
            throw new ArgumentException("Invalid room height. Please enter a positive integer greater than 1 to accommodate the car (1 x 1).");
        }

        return (roomWidth, roomHeight);
    }

    /// <summary>
    /// Validates the car's starting position input.
    /// </summary>
    /// <param name="input">The input string containing the car's starting position and direction.</param>
    /// <param name="room">The room in which the car is located.</param>
    /// <returns>A tuple containing the validated car's X and Y coordinates and direction.</returns>
    public (int carX, int carY, char direction) ValidateCarStartingPosition(string? input, Room room)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("Input cannot be empty. Please enter the starting position and direction.");
        }

        var startPosition = input.Split(' ');
        if (startPosition.Length != 3)
        {
            throw new ArgumentException("Invalid car starting position or direction input. Please enter two integers and a direction character separated by spaces.");
        }

        if (!int.TryParse(startPosition[0], out int carX) || carX < 0 || carX >= room.Width)
        {
            throw new ArgumentException($"Invalid car starting X position. Please enter an integer between 0 and {room.Width - 1}.");
        }

        if (!int.TryParse(startPosition[1], out int carY) || carY < 0 || carY >= room.Height)
        {
            throw new ArgumentException($"Invalid car starting Y position. Please enter an integer between 0 and {room.Height - 1}.");
        }

        if (!char.TryParse(startPosition[2], out char direction) || !AllDirections.Contains(direction))
        {
            throw new ArgumentException("Invalid car direction input. Please enter one of the following characters: N, E, S, W for (North, East, South, West)");
        }

        return (carX, carY, direction);
    }
}