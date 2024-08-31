using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Tests;

public class MovingTests
{
    [Fact]
    public void Moving_ShouldHaveCorrectValues()
    {
        Assert.Equal(0, (int)Moving.None);
        Assert.Equal(1, (int)Moving.Left);
        Assert.Equal(2, (int)Moving.Right);
        Assert.Equal(3, (int)Moving.Forward);
        Assert.Equal(4, (int)Moving.Backward);
    }
}
