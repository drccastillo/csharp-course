using NotificationApp.Services;
using Xunit;
using System;
using System.IO;

public class EmailSenderTests
{
    [Fact]
    public void SendEmail_WritesExpectedOutput()
    {
        var sender = new EmailSender();
        using var sw = new StringWriter();
        Console.SetOut(sw);
        sender.SendEmail("to@example.com", "subject", "body");
        var output = sw.ToString();
        Assert.Contains("Sending Email to to@example.com: subject -> body", output);
    }
}
