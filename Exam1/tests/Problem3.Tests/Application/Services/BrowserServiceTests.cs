using Problem3.Application.Services;
using Problem3.Domain.Interfaces;
using Problem3.Infrastructure;

public class BrowserServiceTests
{
    private readonly IHistoryStore _store;
    private readonly IBrowserService _browser;

    public BrowserServiceTests()
    {
        _store = new HistoryStore();
        _browser = new BrowserService(_store);
    }

    [Fact]
    public void Navigate_SetsCurrentPage()
    {
        _browser.Navigate("https://a.com");
        Assert.Equal("https://a.com", _browser.Current());
    }

    [Fact]
    public void Back_ReturnsPreviousPage()
    {
        _browser.Navigate("https://a.com");
        _browser.Navigate("https://b.com");
        _browser.Back();
        Assert.Equal("https://a.com", _browser.Current());
    }

    [Fact]
    public void Forward_ReturnsNextPage()
    {
        _browser.Navigate("https://a.com");
        _browser.Navigate("https://b.com");
        _browser.Back();
        _browser.Forward();
        Assert.Equal("https://b.com", _browser.Current());
    }

    [Fact]
    public void Navigate_ClearsForwardStack()
    {
        _browser.Navigate("https://a.com");
        _browser.Navigate("https://b.com");
        _browser.Back();
        _browser.Navigate("https://c.com");
        _browser.Forward(); // should do nothing
        Assert.Equal("https://c.com", _browser.Current());
    }

    [Fact]
    public void Back_AtStart_ReturnsCurrent()
    {
        _browser.Navigate("https://only.com");
        _browser.Back();
        Assert.Equal("https://only.com", _browser.Current());
    }

    [Fact]
    public void Forward_WithoutBack_DoesNothing()
    {
        _browser.Navigate("https://only.com");
        _browser.Forward();
        Assert.Equal("https://only.com", _browser.Current());
    }
}