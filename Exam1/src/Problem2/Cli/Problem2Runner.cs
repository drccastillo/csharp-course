using Microsoft.Extensions.Hosting;
using Problem2.Application.Services;

public class Problem2Runner(IPrintBalancerService service) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        service.EnqueueJob("J1");
        service.EnqueueJob("J2");
        service.EnqueueJob("J3");

        service.AssignNext();
        service.AssignNext();

        service.CompleteJob("Printer1", "J1");
        service.AssignNext();

        Console.WriteLine(service.Status());

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}