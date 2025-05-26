using Problem4.Infrastructure;
using System;
using System.IO;

public class OrderLoggerTests
{
    [Fact]
    public void Log_AddsMessagesToInternalList()
    {
        var logger = new OrderLogger();
        logger.Log("msg1");
        logger.Log("msg2");

        var logsField = typeof(OrderLogger).GetField("_logs", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var logs = logsField?.GetValue(logger) as System.Collections.Generic.List<string>;
        Assert.NotNull(logs);
        Assert.Contains("msg1", logs);
        Assert.Contains("msg2", logs);
    }

    [Fact]
    public void Flush_WritesAllLogsToConsoleAndClearsList()
    {
        var logger = new OrderLogger();
        logger.Log("log1");
        logger.Log("log2");
        using var sw = new StringWriter();
        Console.SetOut(sw);
        logger.Flush();
        var output = sw.ToString();
        Assert.Contains("log1", output);
        Assert.Contains("log2", output);

        var logsField = typeof(OrderLogger).GetField("_logs", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var logs = logsField?.GetValue(logger) as System.Collections.Generic.List<string>;
        Assert.NotNull(logs); // Ensure logs is not null before checking if it's empty
        Assert.Empty(logs);
    }

    [Fact]
    public void Flush_OnEmptyLogger_DoesNotThrowOrWrite()
    {
        var logger = new OrderLogger();
        using var sw = new StringWriter();
        Console.SetOut(sw);
        logger.Flush();
        var output = sw.ToString();
        Assert.True(string.IsNullOrEmpty(output));
    }
}
