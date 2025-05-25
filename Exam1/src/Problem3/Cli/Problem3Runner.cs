using Microsoft.Extensions.Hosting;
using Problem3.Application.Services;

public class Problem3Runner(IBrowserService browser) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        browser.Navigate("https://example.com");
        browser.Navigate("https://google.com");
        browser.Back();
        browser.Forward();
        browser.Navigate("https://github.com");
        browser.Back();

        Console.WriteLine("Current page: " + browser.Current());

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
