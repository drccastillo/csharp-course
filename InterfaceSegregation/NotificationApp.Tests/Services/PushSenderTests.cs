using NotificationApp.Services;
using Xunit;
using System;
using System.IO;

public class PushSenderTests
{
    [Fact]
    public void SendPush_WritesExpectedOutput()
    {
        var sender = new PushSender();
        using var sw = new StringWriter();
        Console.SetOut(sw);
        sender.SendPush("token123", "title", "msg");
        var output = sw.ToString();
        Assert.Contains("Sending Push Notification to token123: title - msg", output);
    }
}
