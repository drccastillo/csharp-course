using Problem4.Application.Services;
using Problem4.Domain.Interfaces;
using Problem4.Infrastructure;
using Problem4.Domain.Models;
using System.Collections.Generic;

public class OrderProcessorTests
{
    [Fact]
    public void Process_LogsAllExpectedMessages_Integration()
    {
        var logger = new TestOrderLogger();
        var processor = new OrderProcessor(new OrderValidator(), new OrderFormatter(), logger);

        processor.Process();

        var logs = logger.Logs;
        Assert.Contains(logs, l => l.Contains("A100"));
        Assert.Contains(logs, l => l.Contains("B200"));
        Assert.Contains(logs, l => l.Contains("C300"));
        Assert.Contains(logs, l => l.Contains("Invalid quantity"));
        Assert.Contains(logs, l => l.Contains("Invalid price"));
        Assert.True(logger.Flushed);
    }

    private class TestOrderLogger : IOrderLogger
    {
        public List<string> Logs { get; } = new();
        public bool Flushed { get; private set; } = false;
        public void Log(string message) => Logs.Add(message);
        public void Flush() => Flushed = true;
    }
}
