using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Events;
using RadioControlledCarSimulator.Helpers;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Validation;

namespace RadioControlledCarSimulator;

/// <summary>
/// The main entry point for the application.
/// </summary>
public class Program
{
    /// <summary>
    /// The main method that starts the application.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    public static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
                 .ConfigureServices((context, services) =>
                 {
                     services.AddSingleton<IIOHelper, IOHelper>()
                             .AddScoped<ICommandProcessor, CommandProcessor>()
                             .AddSingleton<Simulator>()
                             .AddSingleton<ICarEvent, CarEvent>()
                             .AddSingleton<IValidator, Validator>();
                 })
                 .Build();

        var simulator = host.Services.GetRequiredService<Simulator>();
        await simulator.RunAsync();
    }
}