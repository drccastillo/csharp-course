# Interface Segregation (ISP)

Clients should not be forced to depend on methods (intefaces, modules, packages) they do not use. Instead of one "fat" interface, provide several, smaller, role specifc interfaces so cunsumers can pick only what they need.

## Scenario

A CLI tool utility that processes order events and notifies customers by email, SMS and push.

## Example (bad)

The first design exposes one monster interface:

```csharp
public interface INotifier
{
  void SendEmail(string to, string subject, string body);
  void SendSms(string to, string text);
  void SendPush(string deviceToken, string title, string message);
}
```

Now every concrete notifier must implement all three methods even if it can only do one:

```csharp
public class SmsNotifier : INotifier
{
  public void SendEmail(string to, string subject, string body)
  {
    throw new NotSupportedException();
  }

  public void SendSms(string to, string text)
  {
    Console.WriteLine($"Sending SMS to {to}: {text}");
  }

  public void SendPush(string deviceToken, string title, string message)
  {
    throw new NotSupportedException();
  }
}
```

If someone adds a new method to send a notification the whole interface should change so, all methods now must implement a methods that they won't use.

## Example (solution)

Split the big contract into focused interfaces and depend on them where needed. Order processing needs only subset, so a small facade aggregates the required roles.

Now each class depends only the capabilities it needs; adding Mobile client, Web client, can be added and we don't need any change regarding scalability

> Note: Depending on the context the solution might be wrong.
> Note 2: We didn't implement strategy pattern correctly. Not even simplified.

## Summary

This implementation applies the Interface Segregation Principle by defining focused interfaces (`IEmailSender`, `ISmsSender`, `IPushSender`) and using a `NotificationFacade` to aggregate only the required notification channels. The `OrderEvent` model uses a `NotificationType[]` to specify the channels dynamically.

### Implemented Tasks
| File                              | Task                                                         | Classification |
|-----------------------------------|--------------------------------------------------------------|----------------|
| `Models/OrderEvent.cs`            | Replaced individual flags with `NotificationType[]` enum list | Required       |
| `Services/NotificationFacade.cs`  | Updated `Notify` logic to iterate over `NotificationTypes`    | Required       |
| `Tests/Services/TestNotificationFacade.cs` | Updated tests to match new signature and added negative scenario | Required       |

### Design Decisions & Patterns
- **Facade Pattern**: `NotificationFacade` simplifies multiple notification channels behind a single interface.
- **Interface Segregation**: Separate interfaces for email, SMS, and push notifications.
- **Enum-based Configuration**: `NotificationType` enum drives channel selection in `OrderEvent`.

## UML Class Diagram

![UML Diagram](uml/diagram.puml)
