namespace NotificationApp.Interfaces;

public interface IEmailSender : INotification
{
  void SendEmail(string to, string subject, string body);
}
