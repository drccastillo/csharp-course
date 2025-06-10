using System;
using System.Threading.Tasks;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.Services;
using Xunit;

namespace WeatherApp.Tests.Services
{
    public class SecondHttpWeatherProviderTests
    {
        [Fact]
        public async Task GetTodayAsync_ValidCurrentWeatherForecast_ReturnsTemperature()
        {
            // Arrange
            var mockForecast = new CurrentWeatherForecastDto(
                0, 0,
                new CurrentWeatherDto(10.5, 5.0, 150.0, 1, DateTime.UtcNow.ToString("O")));
            var fakeService = new StubHttpService<CurrentWeatherForecastDto>(mockForecast);
            var provider = new SecondHttpWeatherProvider(fakeService);

            // Act
            var temp = await provider.GetTodayAsync(new Coordinates(1, 2));

            // Assert
            Assert.Equal(10.5, temp);
        }

        [Fact]
        public async Task GetTodayAsync_NullForecast_ThrowsInvalidOperationException()
        {
            // Arrange
            var fakeService = new StubHttpService<CurrentWeatherForecastDto>(null);
            var provider = new SecondHttpWeatherProvider(fakeService);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => provider.GetTodayAsync(new Coordinates(1, 2)));
        }

        private class StubHttpService<TDto> : IHttpService
        {
            private readonly TDto? _dto;

            public StubHttpService(TDto? dto) => _dto = dto;

            public Task<T?> GetFromJsonAsync<T>(string url)
            {
                if (_dto is T t)
                    return Task.FromResult<T?>(t);
                return Task.FromResult<T?>(default);
            }
        }
    }
}