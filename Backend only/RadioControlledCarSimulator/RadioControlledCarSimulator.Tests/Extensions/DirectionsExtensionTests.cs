using RadioControlledCarSimulator.Extensions;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Tests;

public class DirectionsExtensionTests
{
    [Theory]
    [InlineData('N', Directions.North)]
    [InlineData('E', Directions.East)]
    [InlineData('S', Directions.South)]
    [InlineData('W', Directions.West)]
    [InlineData('X', Directions.None)]
    public void ToDirections_ShouldReturnCorrectDirection(char input, Directions expected)
    {
        // Act
        var result = input.ToDirections();

        // Assert
        Assert.Equal(expected, result);
    }
}

