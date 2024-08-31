using RadioControlledCarSimulator.Models;
using System.Globalization;

namespace RadioControlledCarSimulator.Extensions;

/// <summary>
/// Provides extension methods for the Directions enum.
/// </summary>
public static class DirectionsExtension
{
    /// <summary>
    /// Converts a direction code to a Directions enum value.
    /// </summary>
    /// <param name="directionCode">The direction code.</param>
    /// <returns>The corresponding Directions enum value.</returns>
    public static Directions ToDirections(this char directionCode)
    {
        return char.ToUpper(directionCode, CultureInfo.CurrentCulture) switch
        {
            'N' => Directions.North,
            'E' => Directions.East,
            'S' => Directions.South,
            'W' => Directions.West,
            _ => Directions.None
        };
    }
}