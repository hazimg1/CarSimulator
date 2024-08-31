using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Extensions;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using System.Drawing;

namespace RadioControlledCarSimulator.Helpers;

public class IOHelper : IIOHelper
{
    private const string AllDirections = "EeWwNnSs";
    private readonly IValidator validator;

    public IOHelper(IValidator validator)
    {
        this.validator = validator;
    }

    public async Task<Room> GetRoomInputAsync()
    {
        Console.WriteLine("Enter room dimensions (width height):");
        var input = await Console.In.ReadLineAsync();
        (int roomWidth, int roomHeight) = validator.ValidateRoomDimensions(input);

        return new Room(roomWidth, roomHeight);
    }

    public async Task<Car> GetCarInputAsync(Room room)
    {
        Console.WriteLine("Enter starting position and direction (x y direction):");
        var input = await Console.In.ReadLineAsync();
        (int carX, int carY, char directionChar)= validator.ValidateCarStartingPosition(input, room);

        var startPosition = input!.Split(' ');
        return new Car(carX, carY, directionChar.ToDirections(), room);
    }

    public void CarProgressOutputResult(bool success, Point location, Moving moving, Directions direction) =>
       Console.WriteLine(success
           ? $"Car is moved {moving} to position: ({location.X}, {location.Y}) facing {direction}"
           : "The car cannot continue because it has crashed into a wall.");

    public void CarProgressOutputResult(Moving moving, Directions direction) => Console.WriteLine($"Car is turned {moving} toward {direction}");


    public void OutputResult(bool success, Car car) =>
        Console.WriteLine(success
            ? $"Success! Final position: ({car.X}, {car.Y}) facing {car.Direction}"
            : "Unsuccessful! The car has crashed.");

    public async IAsyncEnumerable<ICommand> GetActionCommandsAsync(Car car)
    {
        Console.WriteLine("Enter action commands (F, B, L, R):");
        var commands = await Console.In.ReadLineAsync();
        foreach (var command in commands ?? string.Empty)
        {
            var cmd = CommandFactory.CreateCommand(command, car);
            if (cmd != null)
            {
                yield return cmd;
            }
        }
    }
}
