using RadioControlledCarSimulator.Interfaces;

namespace RadioControlledCarSimulator.Commands;

/// <summary>
/// Processes commands for the car.
/// </summary>
public class CommandProcessor : ICommandProcessor
{
    private readonly List<ICommand> commands;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommandProcessor"/> class.
    /// </summary>
    public CommandProcessor() => commands = new List<ICommand>();

    /// <summary>
    /// Adds a command to the processor asynchronously.
    /// </summary>
    /// <param name="command">The command to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task AddCommandAsync(ICommand command)
    {
        commands.Add(command);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Executes all added commands asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, with a boolean result indicating success.</returns>
    public Task<bool> ExecuteCommandsAsync()
    {
        var success = commands.All(command => command.Execute());
        return Task.FromResult(success);
    }
}