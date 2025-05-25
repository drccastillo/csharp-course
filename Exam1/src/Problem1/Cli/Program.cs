using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Problem1.Application.Services;
using Problem1.Domain.Interfaces;
using Problem1.Infrastructure.Repositories;
using Problem1.Infrastructure.Validators;

Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IExpressionEvaluatorService, ExpressionEvaluatorService>();
        services.AddSingleton<IUndoStackRepository, UndoStackRepository>();
        services.AddSingleton<IExpressionValidator, ExpressionValidator>();
        services.AddHostedService<Problem1Runner>();
    })
    .Build()
    .Run();
