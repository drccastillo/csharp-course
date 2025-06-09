namespace WeatherApp.Interfaces;

using WeatherApp.Models;

public interface IWeatherProvider
{
    Task<double> GetTodayAsync(Coordinates coordinates);
}