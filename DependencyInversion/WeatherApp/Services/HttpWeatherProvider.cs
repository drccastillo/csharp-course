using System;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.Utils;
using System.Globalization;

namespace WeatherApp.Services;

public class HttpWeatherProvider(IHttpService httpService) : IWeatherProvider
{
  private readonly IHttpService _httpService = httpService;

  private const string ForecastUrlTemplate = WeatherApiConstants.ForecastUrlTemplate;

  public async Task<double> GetTodayAsync(Coordinates coordinates)
  {
      var url = string.Format(
          ForecastUrlTemplate,
          coordinates.Latitude.ToString("G", CultureInfo.InvariantCulture),
          coordinates.Longitude.ToString("G", CultureInfo.InvariantCulture));

      var forecast = await _httpService.GetFromJsonAsync<ForecastDto>(url);
      if (forecast?.current is null)
      {
          throw new InvalidOperationException("Failed to retrieve weather data from API.");
      }

      return forecast.current.temperature_2m;
  }
}