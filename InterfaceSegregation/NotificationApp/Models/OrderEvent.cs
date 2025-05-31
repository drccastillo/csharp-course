namespace NotificationApp.Models;

/// <summary>
/// Represents an order event with selected notification channels.
/// </summary>
public record OrderEvent(
    int OrderId,
    string Customer,
    string Status,
    string CustomerEmail,
    string CustomerPhone,
    string? DeviceToken,
    NotificationType[] NotificationTypes
);