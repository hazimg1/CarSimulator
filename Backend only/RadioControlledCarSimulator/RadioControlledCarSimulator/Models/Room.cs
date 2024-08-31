namespace RadioControlledCarSimulator.Models;

/// <summary>
/// Represents a room with specified width and height.
/// </summary>
public record Room
{
    /// <summary>
    /// Gets or sets the width of the room.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the room.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Room"/> record with the specified width and height.
    /// </summary>
    /// <param name="Width">The width of the room. Must be a positive integer.</param>
    /// <param name="Height">The height of the room. Must be a positive integer.</param>
    /// <exception cref="ArgumentException">Thrown when the width or height is not a positive integer.</exception>
    public Room(int Width, int Height)
    {
        if (Width <= 0)
        {
            throw new ArgumentException("Room width must be a positive integer.");
        }

        if (Height <= 0)
        {
            throw new ArgumentException("Room height must be a positive integer.");
        }

        this.Width = Width;
        this.Height = Height;
    }
}