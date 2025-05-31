# Liskov Substitution Principle (LSP)

A subtype must be fully substitutable for its base type without altering the correctness of the program. Relying on the base abstraction should work without surprise when handed any subtype, no raised exceptions, no weakened guarantees, no unexpected behavior.

## Scenario

We have a CLI tool that charges customers and issues refunds when orderes are cancelled.

## Example (problem)

```csharp
public interface IPaymentProcessor
{
  void Charge(decimal amount, string reference);
  void Refund(decimal amount, string reference);
}
```

Concrete classes:

```csharp
public class CreditCardProcessor : IPaymentProcessor
{
  public void Charge(decimal amount, string reference)
  {
    Console.WriteLine($"Charging {amount:C} with reference {reference} using PaymentCardProcessor.");
  }

  public void Refund(decimal amount, string reference)
  {
    Console.WriteLine($"Refunding {amount:C} with reference {reference} using PaymentCardProcessor.");
  }
}

public class BitcoinProcessor : IPaymentProcessor
{
  public void Charge(decimal amount, string reference)
  {
    Console.WriteLine($"Charging {amount:C} with reference {reference} using PaymentCardProcessor.");
  }

  public void Refund(decimal amount, string reference)
  {
    throw new NotSupportedException("Bitcoin is irreversible.");
  }
}
```

High-level policy code expects every processor to refund. `BitcoinProcessor` cannot be substituted for the abstraction because it breaks callers, violating LSP.

## Example (solution)

Now any `ICharger` (including `BitcoinPayment`) can replace another in charging context; refund logic depends only on `IRefunder`, so substitutability holds and we don't crash the program.
Satisfies LSP.

## Summary

This implementation applies the Liskov Substitution Principle by segregating charging and refund behavior into `ICharger` and `IRefunder` interfaces. `PaymentRouter` is responsible for routing charge and refund requests, with refund logic refactored for single responsibility. The CLI (`PaymentCli`) validates JSON input for orders and delegates operations to the router.

### Implemented Tasks
| File                                | Task                                                           | Classification |
|-------------------------------------|----------------------------------------------------------------|----------------|
| `Services/PaymentRouter.cs`         | Refactored `TryRefund` for single responsibility principle     | Required       |
| `Cli/PaymentCli.cs`                 | Implemented input validation and error handling for JSON input | Required       |
| `Tests/Services/TestPaymentRouter.cs` | Fixed instantiation syntax and added positive refund scenario    | Required       |

### Design Decisions & Patterns
- **Dependency Injection**: `IPaymentRouter` and implementations injected into CLI.
- **Single Responsibility Principle**: `TryRefund` logic split into methods for clarity.
- **Command-like Routing**: `PaymentRouter` routes to `ICharger` and `IRefunder` instances.

## UML Class Diagram

![UML Diagram](uml/diagram.puml)
