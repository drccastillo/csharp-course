using Problem1.Application.Services;
using Problem1.Domain.Exceptions;
using Problem1.Domain.Interfaces;
using Problem1.Repl.Interfaces;

namespace Problem1.Repl.Commands;

public class InputCommand(
    IExpressionEvaluatorService evaluator,
    IInputValidator validator,
    IConsoleWriter console
) : IReplCommand
{
    public string Name => "input";
    public string Description => "Enter and evaluate an inline expression.";

    public async Task ExecuteAsync(string[] args)
    {
        if (args.Length == 0)
        {
            console.WriteLine("⚠ Please provide an expression after 'input'.");
            return;
        }

        try
        {
            evaluator.Clear();
            foreach (var token in args)
            {
                if (validator.IsNumber(token, out var number))
                    evaluator.EnterNumber(number);
                else if (validator.IsOperator(token, out var op))
                    evaluator.EnterOperator(op);
                else
                    console.WriteLine($"⚠ Token ignored: {token}");
            }
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