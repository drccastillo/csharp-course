using Problem3.Domain.Interfaces;

namespace Problem3.Application.Services;

public class BrowserService(IHistoryStore store) : IBrowserService
{
    public void Navigate(string url) => store.Visit(url);
    public void Back() => store.Back();
    public void Forward() => store.Forward();
    public string? Current() => store.Current();
}