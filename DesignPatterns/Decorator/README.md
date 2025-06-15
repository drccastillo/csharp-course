# Decorator Pattern

## Definition

Decorator is a structural design pattern that lets you attach new behaviors to objects by placing these objects inside special wrapper objects that contain the behaviors.

## Example

We are going to create a **coffee shop ordering system** where we need to add various ingredients and services to a base coffee order **dynamically**.

### Bad example

Inheritance based approach with class explosion

```csharp
// Base coffee class
public abstract class Coffee
{
  // We might have a Coffee class/interface as ingredients saver
  public abstract string GetDescription();
  public abstract decimal GetCost();
}

// We need a class for every combination
public class Espresso : Coffee
{
  public override string GetDescription() => "Espresso";
  public override decimal GetCost() => 2.50m;
}

public class EspressoWithMilk : Coffee {
  public override string GetDescription() => "Espresso with Milk";
  public override decimal GetCost() => 2.50m + 0.60m;
}

public class EspressoWithMilkAndSugar : Cofee {
  public override string GetDescription() => "Espresso with Milk and Sugar";
  public override decimal GetCost() => 2.50m + 0.60m + 0.30m;
}

public class EspressoWithMilkAndSugarAndWhip : Cofee {
  public override string GetDescription() => "Espresso with Milk, Sugar and Whipped Cream";
  public override decimal GetCost() => 2.50m + 0.60m + 0.30m + 0.80m;
}
```

Problems with the approach above:

1. Class explosion: n ingredients = 2^n possible combinations
2. Violates Open/Closed Principle: need new classes for new combinations (at library level)
3. Violating the DRY: Duplicated code across similar classes
4. Hard to maintain and extend
5. Cannot add/remove ingredients dynamically at runtime

## Summary

This implementation refactors the initial inheritance-based example into a Dynamic Decorator pattern. Base coffees and decorators are separated into components and decorator classes, while a Facade and Builder simplify client usage. The solution applies SOLID principles, improves extensibility, and enables runtime configuration of coffee orders.

## Discovered Tasks

| Task                                                                                          | Type  | Resolution                                                                                         |
|-----------------------------------------------------------------------------------------------|-------|----------------------------------------------------------------------------------------------------|
| `// TODO: Replace with your ingredient class/record` in BaseCoffee.cs                          | TODO  | Introduced `Ingredient` record to track name, cost, and calories.                                  |
| `// TODO: Change to ingredient class` in ICoffee interface                                     | TODO  | Updated `GetIngredients` to return `List<Ingredient>`.                                              |
| Commented line for `SizeDecorator` in CoffeeOrderBuilder                                       | NOTE  | Implemented `SizeDecorator` and updated builder to support size customization.                      |
| `// TODO: PRINT RECEIPT ...` in CoffeeShopServiceFacade                                         | TODO  | Added `PrintReceipt` method in facade to display order details, cost, calories, and ingredients.    |

## Design Decisions and Patterns Used

- **Decorator Pattern**: Attach ingredients and size modifications to base `ICoffee` objects.
- **Facade Pattern**: `CoffeeShopServiceFacade` simplifies interactions with the system (menu, creation, receipt).
- **Builder Pattern**: `CoffeeOrderBuilder` demonstrates fluent configuration of decorators.
- **Clean Architecture**: Separation into Models, Interfaces, Services, Utils.
- **SOLID Principles**: SRP, OCP (add new decorators without modifying existing code), DIP (depend on abstractions).

## UML Class Diagram

See [`uml/diagram.puml`](uml/diagram.puml) for the PlantUML diagram of classes and interfaces.