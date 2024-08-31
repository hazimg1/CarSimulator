namespace RadioControlledCarSimulator.Commands.Interfaces;

/// <summary>
/// Processes commands asynchronously.
/// </summary>
public interface ICommandProcessor
{
    /// <summary>
    /// Adds a command to the processor asynchronously.
    /// </summary>
    /// <param name="command">The command to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddCommandAsync(ICommand command);

    /// <summary>
    /// Executes all added commands asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, with a boolean result indicating success.</returns>
    Task<bool> ExecuteCommandsAsync();
}