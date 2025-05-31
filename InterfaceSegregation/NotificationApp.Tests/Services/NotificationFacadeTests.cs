using NotificationApp.Interfaces;
using NotificationApp.Models;
using NotificationApp.Services;

namespace NotificationApp.Tests.Services;

public class NotificationFacadeTests
{
  public sealed class StubSms : ISmsSender
  {
    public bool Called { get; private set; }

    public void SendSms(string to, string text)
    {
      Called = true;
    }
  }

  public sealed class StubPush : IPushSender
  {
    public bool Called { get; private set; }

    public void SendPush(string token, string title, string message)
    {
      Called = true;
    }
  }

  public sealed class StubEmail : IEmailSender
  {
    public bool Called { get; private set; }

    public void SendEmail(string to, string subject, string body)
    {
      throw new NotImplementedException();
    }
  }

    [Fact]
    public void Notify_FacadeCallsOnlyRequestedChannels()
    {
        var email = new StubEmail();
        var sms = new StubSms();
        var push = new StubPush();
        var facade = new NotificationFacade(email, sms, push);

        var orderEvent = new OrderEvent(
            1,
            "Alberth",
            "Packed",
            "alberth@jalasoft.com",
            "+59178945612",
            "345",
            new[] { NotificationType.Sms, NotificationType.Push }
        );

        facade.Notify(orderEvent);

        Assert.True(sms.Called);
        Assert.True(push.Called);
        Assert.False(email.Called);
    }

    [Fact]
    public void Notify_NoChannelsSpecified_DoesNotCallAnySenders()
    {
        var email = new StubEmail();
        var sms = new StubSms();
        var push = new StubPush();
        var facade = new NotificationFacade(email, sms, push);

        var orderEvent = new OrderEvent(
            1,
            "Alberth",
            "Packed",
            "alberth@jalasoft.com",
            "+59178945612",
            null,
            Array.Empty<NotificationType>()
        );

        facade.Notify(orderEvent);

        Assert.False(sms.Called);
        Assert.False(push.Called);
        Assert.False(email.Called);
    }
}