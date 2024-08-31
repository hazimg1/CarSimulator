using RadioControlledCarSimulator.Models;
using System.Drawing;

namespace RadioControlledCarSimulator.Interfaces;

/// <summary>
/// Defines methods for input and output operations.
/// </summary>
public interface IIOHelper
{
    /// <summary>
    /// Gets the action commands input asynchronously.
    /// </summary>
    /// <param name="car">The car to control.</param>
    /// <returns>An asynchronous enumerable of commands.</returns>
    IAsyncEnumerable<ICommand> GetActionCommandsAsync(Car car);

    /// <summary>
    /// Gets the car's starting position input asynchronously.
    /// </summary>
    /// <param name="room">The room in which the car is located.</param>
    /// <returns>A task representing the asynchronous operation, with a result of the car's starting position.</returns>
    Task<Car> GetCarInputAsync(Room room);

    /// <summary>
    /// Gets the room dimensions input asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, with a result of the room dimensions.</returns>
    Task<Room> GetRoomInputAsync();

    /// <summary>
    /// Outputs the final result of the car's operations.
    /// </summary>
    /// <param name="success">Indicates whether the operation was successful.</param>
    /// <param name="car">The car object.</param>
    void OutputResult(bool success, Car car);

    /// <summary>
    /// Outputs the result of the car's progress.
    /// </summary>
    /// <param name="success">Indicates whether the operation was successful.</param>
    /// <param name="location">The current location of the car.</param>
    /// <param name="moving">The direction in which the car is moving.</param>
    /// <param name="direction">The current direction the car is facing.</param>
    void CarProgressOutputResult(bool success, Point location, Moving moving, Directions direction);

    /// <summary>
    /// Outputs the result of the car's turning progress.
    /// </summary>
    /// <param name="moving">The direction in which the car is turning.</param>
    /// <param name="direction">The current direction the car is facing.</param>
    void CarProgressOutputResult(Moving moving, Directions direction);
}