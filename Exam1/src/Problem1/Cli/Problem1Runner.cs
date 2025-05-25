using Microsoft.Extensions.Hosting;
using Problem1.Application.Services;
using Problem1.Domain.Exceptions;

public class Problem1Runner(IExpressionEvaluatorService service) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        service.EnterNumber(5);
        service.EnterOperator('+');
        service.EnterNumber(3);
        service.EnterOperator('*');
        service.EnterNumber(2);

        Console.WriteLine("Current Result: " + service.Evaluate()); // Expect 11
        try
        {
            service.Undo();
            Console.WriteLine("After another Undo: " + service.Evaluate());
        }
        catch (InvalidExpressionException ex)
        {
            Console.WriteLine("Caught exception: " + ex.Message);
        }


        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}