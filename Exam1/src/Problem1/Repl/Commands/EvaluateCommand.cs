using Problem1.Application.Services;
using Problem1.Domain.Exceptions;
using Problem1.Repl.Interfaces;

namespace Problem1.Repl.Commands;

public class EvaluateCommand(
    IExpressionEvaluatorService evaluator,
    IConsoleWriter console
) : IReplCommand
{
    public string Name => "evaluate";
    public string Description => "Evaluate the current expression.";

    public async Task ExecuteAsync(string[] args)
    {
        try
        {
            var result = evaluator.Evaluate();
            console.WriteLine($"= {result}");
        }
        catch (InvalidExpressionException ex)
        {
            console.WriteLine($"❌ Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            console.WriteLine($"❌ Unexpected error: {ex.Message}");
        }

        await Task.CompletedTask;
    }
}
