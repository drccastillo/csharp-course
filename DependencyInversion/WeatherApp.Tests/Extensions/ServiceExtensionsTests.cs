using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Extensions;
using WeatherApp.Interfaces;
using WeatherApp.Services;
using Xunit;

namespace WeatherApp.Tests.Extensions
{
    public class ServiceExtensionsTests
    {
        [Theory]
        [InlineData(true, typeof(HttpWeatherProvider))]
        [InlineData(false, typeof(SecondHttpWeatherProvider))]
        public void AddCliServices_RegistersExpectedWeatherProvider(bool useDefault, System.Type expectedProviderType)
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddCliServices(useDefault);
            var provider = services.BuildServiceProvider().GetService<IWeatherProvider>();

            // Assert
            Assert.NotNull(provider);
            Assert.IsType(expectedProviderType, provider);
        }

        [Fact]
        public void AddCliServices_RegistersHttpServiceAndHttpClientAndCli()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddCliServices(true);
            var sp = services.BuildServiceProvider();

            // Assert
            Assert.NotNull(sp.GetService<HttpClient>());
            Assert.IsType<HttpService>(sp.GetService<IHttpService>());
            Assert.NotNull(sp.GetService<WeatherCli>());
        }
    }
}