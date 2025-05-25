using Problem2.Application.Services;
using Problem2.Domain.Interfaces;
using Problem2.Domain.Models;
using Problem2.Infrastructure;

public class PrintBalancerServiceTests
{
    private readonly IPrintRepository _repo;
    private readonly IPrintBalancerService _service;

    public PrintBalancerServiceTests()
    {
        _repo = new PrintRepository();
        _service = new PrintBalancerService(_repo);
    }

    [Fact]
    public void EnqueueJob_AddsJobToQueue()
    {
        _service.EnqueueJob("Job1");
        Assert.Single(_repo.WaitingJobs);
    }

    [Fact]
    public void AssignNext_AssignsToIdlePrinter()
    {
        _service.EnqueueJob("Job1");
        _service.AssignNext();
        Assert.Contains(_repo.Printers.Values, j => j?.JobId == "Job1");
    }

    [Fact]
    public void CompleteJob_SetsPrinterToIdle()
    {
        _service.EnqueueJob("Job1");
        _service.AssignNext();
        _service.CompleteJob("Printer1", "Job1");
        Assert.Null(_repo.Printers["Printer1"]);
    }

    [Fact]
    public void Status_ReturnsExpectedFormat()
    {
        _service.EnqueueJob("Job1");
        _service.AssignNext();
        string status = _service.Status();
        Assert.Contains("Printer1", status);
        Assert.Contains("Job1", status);
    }

    [Fact]
    public void AssignNext_SkipsIfNoIdlePrinter()
    {
        _service.EnqueueJob("J1");
        _service.EnqueueJob("J2");
        _service.EnqueueJob("J3");

        _service.AssignNext();
        _service.AssignNext();
        _service.AssignNext(); // no effect

        Assert.Single(_repo.WaitingJobs);
    }
}