using System.Threading.Tasks;

namespace WeatherApp.Interfaces
{
    public interface IHttpService
    {
        Task<T?> GetFromJsonAsync<T>(string url);
    }
}