using Microsoft.Extensions.Logging;

namespace RadioControlledCarSimulator.Helpers;

/// <summary>
/// Provides helper methods for logging.
/// </summary>
public static class LoggerDefinitions
{
    private const int SimulatorStartedEventId = 1;
    private const int RoomDimensionsReceivedEventId = 2;
    private const int CarStartingPositionEventId = 3;
    private const int CommandsExecutedEventId = 4;
    private const int InvalidInputFormatEventId = 5;
    private const int ArgumentErrorEventId = 6;
    private const int UnexpectedErrorEventId = 7;
    private const int SimulatorFinishedEventId = 8;

    internal static readonly Action<ILogger, Exception?> LogSimulatorStarted =
        LoggerMessage.Define(LogLevel.Information, new EventId(SimulatorStartedEventId, nameof(LogSimulatorStarted)), "Simulator started.");
    internal static readonly Action<ILogger, int, int, Exception?> LogRoomDimensionsReceived =
        LoggerMessage.Define<int, int>(LogLevel.Information, new EventId(RoomDimensionsReceivedEventId, nameof(LogRoomDimensionsReceived)), "Room dimensions received: {Width}x{Height}");
    internal static readonly Action<ILogger, int, int, string, Exception?> LogCarStartingPosition =
        LoggerMessage.Define<int, int, string>(LogLevel.Information, new EventId(CarStartingPositionEventId, nameof(LogCarStartingPosition)), "Car starting position: ({X}, {Y}) facing {Direction}");
    internal static readonly Action<ILogger, bool, Exception?> LogCommandsExecuted =
        LoggerMessage.Define<bool>(LogLevel.Information, new EventId(CommandsExecutedEventId, nameof(LogCommandsExecuted)), "Commands executed. Success: {Success}");
    internal static readonly Action<ILogger, Exception?> LogInvalidInputFormat =
        LoggerMessage.Define(LogLevel.Error, new EventId(InvalidInputFormatEventId, nameof(LogInvalidInputFormat)), "Invalid input format.");
    internal static readonly Action<ILogger, Exception?> LogArgumentError =
        LoggerMessage.Define(LogLevel.Error, new EventId(ArgumentErrorEventId, nameof(LogArgumentError)), "Argument error.");
    internal static readonly Action<ILogger, Exception?> LogUnexpectedError =
        LoggerMessage.Define(LogLevel.Error, new EventId(UnexpectedErrorEventId, nameof(LogUnexpectedError)), "An unexpected error occurred.");
    internal static readonly Action<ILogger, Exception?> LogSimulatorFinished =
        LoggerMessage.Define(LogLevel.Information, new EventId(SimulatorFinishedEventId, nameof(LogSimulatorFinished)), "Simulator finished.");
}