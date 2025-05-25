using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Problem3.Application.Services;
using Problem3.Domain.Interfaces;
using Problem3.Infrastructure;

Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IBrowserService, BrowserService>();
        services.AddSingleton<IHistoryStore, HistoryStore>();
        services.AddHostedService<Problem3Runner>();
    })
    .Build()
    .Run();