using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherApp.Interfaces;

namespace WeatherApp.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient) => _httpClient = httpClient;

        public Task<T?> GetFromJsonAsync<T>(string url)
            => _httpClient.GetFromJsonAsync<T>(url);
    }
}