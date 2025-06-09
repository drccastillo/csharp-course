namespace WeatherApp.Models;

public record CurrentWeatherForecastDto(
    double latitude,
    double longitude,
    CurrentWeatherDto current_weather
);

public record CurrentWeatherDto(
    double temperature,
    double windspeed,
    double winddirection,
    int is_day,
    string time
);