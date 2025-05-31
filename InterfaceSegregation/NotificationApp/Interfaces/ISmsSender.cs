namespace NotificationApp.Interfaces;

public interface ISmsSender : INotification
{
  void SendSms(string to, string text);
}
