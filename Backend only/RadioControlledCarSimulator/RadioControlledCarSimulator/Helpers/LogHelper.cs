using Microsoft.Extensions.Logging;

namespace RadioControlledCarSimulator.Helpers;

/// <summary>
/// Provides helper methods for logging.
/// </summary>
public static class LogHelper
{
    public static void LogSimulatorStarted(ILogger logger) => LoggerDefinitions.LogSimulatorStarted(logger, null);
    public static void LogRoomDimensionsReceived(ILogger logger, int width, int height) => LoggerDefinitions.LogRoomDimensionsReceived(logger, width, height, null);
    public static void LogCarStartingPosition(ILogger logger, int x, int y, string direction) => LoggerDefinitions.LogCarStartingPosition(logger, x, y, direction, null);
    public static void LogCommandsExecuted(ILogger logger, bool success) => LoggerDefinitions.LogCommandsExecuted(logger, success, null);
    public static void LogInvalidInputFormat(ILogger logger, Exception ex) => LoggerDefinitions.LogInvalidInputFormat(logger, ex);
    public static void LogArgumentError(ILogger logger, Exception ex) => LoggerDefinitions.LogArgumentError(logger, ex);
    public static void LogUnexpectedError(ILogger logger, Exception ex) => LoggerDefinitions. LogUnexpectedError(logger, ex);
    public static void LogSimulatorFinished(ILogger logger) => LoggerDefinitions.LogSimulatorFinished(logger, null);
}