using System;
using System.Threading.Tasks;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.Services;
using Xunit;

namespace WeatherApp.Tests.Services
{
    public class HttpWeatherProviderTests
    {
        [Fact]
        public async Task GetTodayAsync_ValidResponse_ReturnsTemperature()
        {
            // Arrange
            var fakeService = new StubHttpService(new ForecastDto(0, 0, new CurrentDto("", 0, 15.5)));
            var provider = new HttpWeatherProvider(fakeService);

            // Act
            var temp = await provider.GetTodayAsync(new Coordinates(1, 2));

            // Assert
            Assert.Equal(15.5, temp);
        }

        [Fact]
        public async Task GetTodayAsync_NullResponse_Throws()
        {
            // Arrange
            var fakeService = new StubHttpService<ForecastDto>(null);
            var provider = new HttpWeatherProvider(fakeService);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                provider.GetTodayAsync(new Coordinates(1, 2)));
        }

        private class StubHttpService : IHttpService
        {
            private readonly ForecastDto? _dto;

            public StubHttpService(ForecastDto? dto) => _dto = dto;

            public Task<T?> GetFromJsonAsync<T>(string url) => Task.FromResult(_dto as T);
        }

        private class StubHttpService<T> : IHttpService
        {
            private readonly T? _dto;

            public StubHttpService(T? dto) => _dto = dto;

            public Task<TOut?> GetFromJsonAsync<TOut>(string url) where TOut : class => Task.FromResult(_dto as TOut);
        }
    }
}