using Problem1.Application.Services;
using Problem1.Repl.Interfaces;

namespace Problem1.Repl.Commands;

public class ClearCommand(IExpressionEvaluatorService evaluator, IConsoleWriter console) : IReplCommand
{
    public string Name => "clear";
    public string Description => "Clear the expression stack.";

    public async Task ExecuteAsync(string[] args)
    {
        evaluator.Clear();
        console.WriteLine("🧹 Expression stack cleared.");
        await Task.CompletedTask;
    }
}