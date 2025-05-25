using Microsoft.Extensions.Hosting;
using Problem1.Repl.Interfaces;
using Problem1.Repl.Core;

namespace Problem1.Repl;

public class Problem1ReplRunner(
    IConsoleWriter console,
    ReplCommandRegistry registry
) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        console.WriteLine("🧮 Expression Evaluator REPL — type 'help' for commands");

        while (true)
        {
            console.WritePrompt();
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;

            var tokens = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var cmd = tokens[0].ToLower();
            var args = tokens.Skip(1).ToArray();

            switch (cmd)
            {
                case "exit":
                    return Task.CompletedTask;

                case "help":
                    foreach (var c in registry.All())
                        console.WriteLine($"{c.Name} - {c.Description}");
                    break;

                default:
                    if (registry.TryResolve(cmd, out var command)&& command is not null)
                        command.ExecuteAsync(args).Wait();
                    else
                        console.WriteLine("❌ Unknown command — type 'help' for usage.");
                    break;
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
