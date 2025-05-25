using Problem2.Domain.Interfaces;
using Problem2.Domain.Models;
using System.Text;

namespace Problem2.Application.Services;

public class PrintBalancerService(IPrintRepository repo) : IPrintBalancerService
{
    public void EnqueueJob(string jobId) => repo.WaitingJobs.Enqueue(new PrintJob(jobId));

    public void AssignNext()
    {
        if (repo.WaitingJobs.Count == 0) return;
        var nextJob = repo.WaitingJobs.Peek();

        var target = repo.Printers.FirstOrDefault(p => p.Value is null).Key;
        if (target != null && repo.Printers[target] == null)
        {
            repo.Printers[target] = repo.WaitingJobs.Dequeue();
        }
    }

    public void CompleteJob(string printerId, string jobId)
    {
        if (repo.Printers.TryGetValue(printerId, out var job) && job?.JobId == jobId)
        {
            repo.Printers[printerId] = null;
        }
    }

    public string Status()
    {
        var sb = new StringBuilder();
        sb.AppendLine("-- Waiting Jobs --");
        foreach (var job in repo.WaitingJobs)
            sb.AppendLine(job.JobId);

        sb.AppendLine("-- Printer Status --");
        foreach (var printer in repo.Printers)
        {
            var job = printer.Value?.JobId ?? "idle";
            sb.AppendLine($"{printer.Key}: {job}");
        }
        return sb.ToString();
    }
}