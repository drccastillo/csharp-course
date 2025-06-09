namespace WeatherApp.Utils
{
    public static class WeatherApiConstants
    {
        public const string ForecastUrlTemplate =
            "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m";

        /// <summary>
        /// Open-Meteo endpoint for current weather only.
        /// </summary>
        public const string CurrentWeatherUrlTemplate =
            "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&current_weather=true";
    }
}