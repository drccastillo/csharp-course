using NotificationApp.Interfaces;
using NotificationApp.Models;

namespace NotificationApp.Services;

// NOTE: This can be MobileNotiicationFacade depends on the context
public class NotificationFacade(IEmailSender email, ISmsSender sms, IPushSender push) : INotificationFacade
{
  private readonly IEmailSender _emailSender = email;
  private readonly ISmsSender _smsSender = sms;
  private readonly IPushSender _pushSender = push;

    // OPTIONAL: Create a high interface INotification for all notification types (BTW, the notifacion types might empty)
    public void Notify(OrderEvent orderEvent)
    {
        var subject = $"Order #{orderEvent.OrderId} status: {orderEvent.Status}";
        var body = $"Hi {orderEvent.Customer}, your order is now {orderEvent.Status}";

        foreach (var notificationType in orderEvent.NotificationTypes)
        {
            switch (notificationType)
            {
                case NotificationType.Email:
                    _emailSender.SendEmail(orderEvent.CustomerEmail, subject, body);
                    break;
                case NotificationType.Sms:
                    _smsSender.SendSms(orderEvent.CustomerPhone, body);
                    break;
                case NotificationType.Push:
                    if (!string.IsNullOrEmpty(orderEvent.DeviceToken))
                    {
                        _pushSender.SendPush(orderEvent.DeviceToken, "Order Update", body);
                    }
                    break;
            }
        }
    }
}