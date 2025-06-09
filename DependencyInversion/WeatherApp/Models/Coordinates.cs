using System;
using System.Globalization;

namespace WeatherApp.Models
{
    public readonly record struct Coordinates(double Latitude, double Longitude)
    {
        public static Coordinates Parse(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Coordinates string must be non-empty", nameof(value));
            }

            var parts = value.Split(',', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2
                || !double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var lat)
                || !double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var lon))
            {
                throw new FormatException($"Invalid coordinates format: '{value}'. Expected format: 'latitude,longitude'.");
            }

            return new Coordinates(lat, lon);
        }
    }
}