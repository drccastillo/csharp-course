using System;
using System.IO;
using System.Threading.Tasks;
using WeatherApp.Cli;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using Xunit;

namespace WeatherApp.Tests.Cli
{
    public class TestWeatherCli
    {
        [Fact]
        public async Task RunAsync_ValidCoordinates_WritesTemperature()
        {
            // Arrange
            var provider = new StubWeatherProvider(20.5);
            var cli = new WeatherCli(provider);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            await cli.RunAsync(new[] { "10,20" });

            // Assert
            var result = output.ToString().Trim();
            Assert.Equal("Today weather is: 20.5 Celsius", result);
        }

        [Fact]
        public async Task RunAsync_InvalidCoordinates_WritesError()
        {
            // Arrange
            var provider = new StubWeatherProvider(0);
            var cli = new WeatherCli(provider);
            var errorOutput = new StringWriter();
            Console.SetError(errorOutput);

            // Act
            await cli.RunAsync(new[] { "invalid" });

            // Assert
            var result = errorOutput.ToString().Trim();
            Assert.StartsWith("Error:", result);
        }

    [Fact]
    public async Task RunAsync_SeparateValidCoordinates_WritesTemperature()
    {
        // Arrange
        var provider = new StubWeatherProviderSeparated();
        var cli = new WeatherCli(provider);
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        await cli.RunAsync(new[] { "1", "2" });

        // Assert
        var result = output.ToString().Trim();
        Assert.Equal("Today weather is: 3 Celsius", result);
    }

        private class StubWeatherProvider : IWeatherProvider
        {
            private readonly double _temp;

            public StubWeatherProvider(double temp) => _temp = temp;

            public Task<double> GetTodayAsync(Coordinates coordinates)
                => Task.FromResult(_temp);
        }

        private class StubWeatherProviderSeparated : IWeatherProvider
        {
            public Task<double> GetTodayAsync(Coordinates coordinates)
                => Task.FromResult(coordinates.Latitude + coordinates.Longitude);
        }
    }
}