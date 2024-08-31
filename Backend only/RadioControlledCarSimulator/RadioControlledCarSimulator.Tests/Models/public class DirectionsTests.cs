using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Tests;

public class DirectionsTests
{
    [Fact]
    public void Directions_ShouldHaveCorrectValues()
    {
        Assert.Equal(0, (int)Directions.None);
        Assert.Equal(1, (int)Directions.North);
        Assert.Equal(2, (int)Directions.East);
        Assert.Equal(3, (int)Directions.West);
        Assert.Equal(4, (int)Directions.South);
    }
}
