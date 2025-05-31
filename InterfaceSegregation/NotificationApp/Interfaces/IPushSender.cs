namespace NotificationApp.Interfaces;

public interface IPushSender : INotification
{
  void SendPush(string deviceToken, string title, string message);
}
