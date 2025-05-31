using System.Collections;
using System.Text.Json;
using NotificationApp.Interfaces;
using NotificationApp.Models;

namespace NotificationApp.Cli;

public class OrderNotifyCli(INotificationFacade notifier)
{
  private readonly INotificationFacade _notifier = notifier;

  private class OrderEventInput
  {
    public int OrderId { get; set; }
    public string Customer { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string? DeviceToken { get; set; }
    public bool NotifyEmail { get; set; }
    public bool NotifySms { get; set; }
    public bool NotifyPush { get; set; }
  }

  public void Run(string[] args)
  {
    var json = args.Length > 0 ? args[0] : SampleJson();
    List<OrderEventInput>? inputs = null;
    try
    {
      inputs = JsonSerializer.Deserialize<List<OrderEventInput>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
    catch (JsonException ex)
    {
      Console.WriteLine($"Error: Invalid JSON input. {ex.Message}");
      return;
    }
    if (inputs == null || inputs.Count == 0)
    {
      Console.WriteLine("Error: No events to process.");
      return;
    }
    foreach (var input in inputs)
    {
      var types = new List<NotificationType>();
      if (input.NotifyEmail) types.Add(NotificationType.Email);
      if (input.NotifySms) types.Add(NotificationType.Sms);
      if (input.NotifyPush) types.Add(NotificationType.Push);
      var orderEvent = new OrderEvent(
        input.OrderId,
        input.Customer,
        input.Status,
        input.CustomerEmail,
        input.CustomerPhone,
        input.DeviceToken,
        types.ToArray()
      );
      _notifier.Notify(orderEvent);
    }
  }

  public static string SampleJson()
  {
    return """
    [
      {
        "orderId": 1,
        "customer": "Carlos",
        "status": "Shipped",
        "notifyEmail": true,
        "notifySms": false,
        "notifyPush": true,
        "customerEmail": "carlos@jalasoft.com",
        "customerPhone": "-59178945612",
        "deviceToken": "abc"
      },
      {
        "orderId": 1,
        "customer": "Jessica",
        "status": "Received",
        "notifyEmail": false,
        "notifySms": true,
        "notifyPush": false,
        "customerEmail": "jessica@jalasoft.com",
        "customerPhone": "+59178565612",
        "deviceToken": null
      }
    ]
    """;
  }
}