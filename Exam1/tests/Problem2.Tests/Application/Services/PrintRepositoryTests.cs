using Problem2.Infrastructure;
using Problem2.Domain.Models;

public class PrintRepositoryTests
{
    [Fact]
    public void InitialState_HasTwoIdlePrinters_AndEmptyQueue()
    {
        var repo = new PrintRepository();
        Assert.Equal(2, repo.Printers.Count);
        Assert.All(repo.Printers.Values, v => Assert.Null(v));
        Assert.Empty(repo.WaitingJobs);
    }

    [Fact]
    public void CanEnqueueAndDequeueJobs()
    {
        var repo = new PrintRepository();
        repo.WaitingJobs.Enqueue(new PrintJob("A"));
        repo.WaitingJobs.Enqueue(new PrintJob("B"));
        Assert.Equal("A", repo.WaitingJobs.Dequeue().JobId);
        Assert.Equal("B", repo.WaitingJobs.Dequeue().JobId);
    }

    [Fact]
    public void CanAssignAndClearPrinter()
    {
        var repo = new PrintRepository();
        var job = new PrintJob("X");
        repo.Printers["Printer1"] = job;
        Assert.Equal(job, repo.Printers["Printer1"]);
        repo.Printers["Printer1"] = null;
        Assert.Null(repo.Printers["Printer1"]);
    }
}
