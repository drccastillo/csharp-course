using NotificationApp.Services;
using Xunit;
using System;
using System.IO;

public class SmsSenderTests
{
    [Fact]
    public void SendSms_WritesExpectedOutput()
    {
        var sender = new SmsSender();
        using var sw = new StringWriter();
        Console.SetOut(sw);
        sender.SendSms("+1234567890", "test message");
        var output = sw.ToString();
        Assert.Contains("Sending SMS to +1234567890: test message", output);
    }
}
