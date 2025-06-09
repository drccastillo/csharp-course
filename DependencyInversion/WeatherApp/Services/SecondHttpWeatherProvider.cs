using System;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.Utils;
using System.Globalization;

namespace WeatherApp.Services;

public class SecondHttpWeatherProvider(IHttpService httpService) : IWeatherProvider
{
  private readonly IHttpService _httpService = httpService;


  public async Task<double> GetTodayAsync(Coordinates coordinates)
  {
      var url = string.Format(
          WeatherApiConstants.CurrentWeatherUrlTemplate,
          coordinates.Latitude.ToString("G", CultureInfo.InvariantCulture),
          coordinates.Longitude.ToString("G", CultureInfo.InvariantCulture));

      var forecast = await _httpService.GetFromJsonAsync<CurrentWeatherForecastDto>(url);
      if (forecast?.current_weather is null)
      {
          throw new InvalidOperationException("Failed to retrieve weather data from API.");
      }

      return forecast.current_weather.temperature;
  }
}