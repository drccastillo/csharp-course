using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Services;
using Xunit;

namespace WeatherApp.Tests.Services
{
    public class HttpServiceTests
    {
        [Fact]
        public async Task GetFromJsonAsync_ReturnsDeserializedObject()
        {
            // Arrange
            var handler = new FakeHttpMessageHandler("{\"Value\":42}");
            var httpClient = new HttpClient(handler);
            var service = new HttpService(httpClient);

            // Act
            var result = await service.GetFromJsonAsync<TestDto>("http://test");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(42, result.Value);
        }

        private class FakeHttpMessageHandler : HttpMessageHandler
        {
            private readonly string _responseContent;

            public FakeHttpMessageHandler(string responseContent)
            {
                _responseContent = responseContent;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(_responseContent)
                };
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return Task.FromResult(response);
            }
        }

        private class TestDto
        {
            public int Value { get; set; }
        }
    }
}