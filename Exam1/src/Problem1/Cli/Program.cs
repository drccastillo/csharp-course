// File: Cli/Program.cs
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Problem1.Application.Services;
using Problem1.Domain.Interfaces;
using Problem1.Infrastructure.Repositories;
using Problem1.Infrastructure.Validators;
using Problem1.Repl.Interfaces;
using Problem1.Repl.Adapters;
using Problem1.Repl.Core;
using Problem1.Repl.Commands;
using Problem1.Repl;

Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IExpressionEvaluatorService, ExpressionEvaluatorService>();
        services.AddSingleton<IUndoStackRepository, UndoStackRepository>();
        services.AddSingleton<IInputValidator, InputValidator>();
        services.AddSingleton<IConsoleWriter, ConsoleWriter>();
        services.AddSingleton<IReplCommand, EvaluateCommand>();
        services.AddSingleton<IReplCommand, UndoCommand>();
        services.AddSingleton<IReplCommand, ClearCommand>();
        services.AddSingleton<IReplCommand, InputCommand>();
        services.AddSingleton<ReplCommandRegistry>(provider =>
        {
            var registry = new ReplCommandRegistry();
            foreach (var command in provider.GetServices<IReplCommand>())
            {
                registry.Register(command);
            }
            return registry;
        });
        services.AddHostedService<Problem1ReplRunner>();
    })
    .Build()
    .Run();
