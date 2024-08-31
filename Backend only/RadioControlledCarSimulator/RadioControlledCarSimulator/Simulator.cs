using Microsoft.Extensions.Logging;
using RadioControlledCarSimulator.Helpers;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator
{
    /// <summary>
    /// Represents the main simulator class.
    /// </summary>
    public class Simulator
    {
        private readonly IIOHelper ioHelper;
        private readonly ICommandProcessor commandProcessor;
        private readonly ILogger<Simulator> logger;
        private readonly ICarEvent carEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="Simulator"/> class.
        /// </summary>
        /// <param name="ioHelper">The I/O helper.</param>
        /// <param name="commandProcessor">The command processor.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="carEvent">The event handler.</param>
        public Simulator(IIOHelper ioHelper, ICommandProcessor commandProcessor, ILogger<Simulator> logger, ICarEvent carEvent)
        {
            this.ioHelper = ioHelper;
            this.commandProcessor = commandProcessor;
            this.logger = logger;
            this.carEvent = carEvent;
        }

        /// <summary>
        /// Runs the simulator asynchronously.
        /// </summary>
        public async Task RunAsync()
        {
            LogHelper.LogSimulatorStarted(logger);
            try
            {
                Room room = await ioHelper.GetRoomInputAsync().ConfigureAwait(false);
                LogHelper.LogRoomDimensionsReceived(logger, room.Width, room.Height);
                Car car = await ioHelper.GetCarInputAsync(room).ConfigureAwait(false);
                car.CarMoved += carEvent.CarMoved;
                car.CarTurned += carEvent.CarTurned;
                LogHelper.LogCarStartingPosition(logger, car.X, car.Y, car.Direction.ToString());

                await ProcessCommandsAsync(car).ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentException)
            {
                HandleKnownExceptions(ex);
            }
            catch (Exception ex)
            {
                LogHelper.LogUnexpectedError(logger, ex);
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            LogHelper.LogSimulatorFinished(logger);
        }

        private void HandleKnownExceptions(Exception ex)
        {

            if (ex is FormatException)
            {
                LogHelper.LogInvalidInputFormat(logger, ex);
                Console.WriteLine("Invalid input format. Please enter the data in the correct format.");
            }
            else if (ex is ArgumentException)
            {
                LogHelper.LogArgumentError(logger, ex);
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task ProcessCommandsAsync(Car car)
        {
            await foreach (ICommand command in ioHelper.GetActionCommandsAsync(car).ConfigureAwait(false))
            {
                await commandProcessor.AddCommandAsync(command).ConfigureAwait(false);
            }

            bool success = await commandProcessor.ExecuteCommandsAsync().ConfigureAwait(false);
            ioHelper.OutputResult(success, car);
            LogHelper.LogCommandsExecuted(logger, success);
        }
    }
}