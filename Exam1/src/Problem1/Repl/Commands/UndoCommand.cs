using Problem1.Application.Services;
using Problem1.Repl.Interfaces;

namespace Problem1.Repl.Commands;

public class UndoCommand(IExpressionEvaluatorService evaluator, IConsoleWriter console) : IReplCommand
{
    public string Name => "undo";
    public string Description => "Undo the last token entered.";

    public async Task ExecuteAsync(string[] args)
    {
        evaluator.Undo();
        console.WriteLine("↩ Last token removed.");
        await Task.CompletedTask;
    }
}