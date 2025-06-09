using System;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using System.Globalization;

namespace WeatherApp.Cli;

public class WeatherCli
{
    private readonly IWeatherProvider _provider;

    private static readonly Coordinates DefaultCoordinates = new(-16.54649d, -68.058805d);

    public WeatherCli(IWeatherProvider provider)
    {
        _provider = provider ?? throw new ArgumentNullException(nameof(provider));
    }

    public async Task RunAsync(string[] args)
    {
        Coordinates coordinates;
        try
        {
            if (args.Length >= 2)
            {
                if (!double.TryParse(args[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var lat)
                    || !double.TryParse(args[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var lon))
                {
                    throw new FormatException($"Invalid coordinates format: '{args[0]}','{args[1]}'. Expected numeric latitude and longitude.");
                }
                coordinates = new Coordinates(lat, lon);
            }
            else if (args.Length == 1)
            {
                coordinates = Coordinates.Parse(args[0]);
            }
            else
            {
                coordinates = DefaultCoordinates;
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            return;
        }

        var temperature = await _provider.GetTodayAsync(coordinates);
        Console.WriteLine($"Today weather is: {temperature} Celsius");
    }
}