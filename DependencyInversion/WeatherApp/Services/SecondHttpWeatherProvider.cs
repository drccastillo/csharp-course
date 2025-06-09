using System;
using System.Net.Http.Json;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Services;

public class SecondHttpWeatherProvider(HttpClient httpClient) : IWeatherProvider
{
  private readonly HttpClient _httpClient = httpClient;

  private const string ForecastUrlTemplate =
    "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m";

  public async Task<double> GetTodayAsync(string latitude, string longitude)
  {
    // OPTIONAL: Search for a new endpoint to get the weather (refactor scaffolding for models)
    var url = string.Format(ForecastUrlTemplate, latitude, longitude);
    var response = await _httpClient.GetFromJsonAsync<ForecastDto>(url);

    return response!.current.temperature_2m;
  }
}