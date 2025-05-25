using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Problem2.Application.Services;
using Problem2.Domain.Interfaces;
using Problem2.Infrastructure;

Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IPrintBalancerService, PrintBalancerService>();
        services.AddSingleton<IPrintRepository, PrintRepository>();
        services.AddHostedService<Problem2Runner>();
    })
    .Build()
    .Run();