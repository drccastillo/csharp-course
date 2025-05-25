using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Problem4.Application.Services;
using Problem4.Domain.Interfaces;
using Problem4.Infrastructure;

Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IOrderValidator, OrderValidator>();
        services.AddSingleton<IOrderFormatter, OrderFormatter>();
        services.AddSingleton<IOrderLogger, OrderLogger>();
        services.AddSingleton<OrderProcessor>();
    })
    .Build()
    .Services
    .GetRequiredService<OrderProcessor>()
    .Process();
