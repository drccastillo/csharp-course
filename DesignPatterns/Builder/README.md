# Builder Design Pattern

## Definition

Builder is a creational design pattern that lets you construct complex objects step by step. The pattern allows you to produce different types and representations of an object using the same construction code.

## When to use

- Use the Builder pattern to get rid of a “telescoping constructor”.
- Use the Builder pattern when you want your code to be able to create different representations of some product (for example, stone and wooden houses).

## Summary

This implementation refactors the initial bad SQL builder example into a robust Builder pattern. The `SQLQuery` model captures query clauses, `StandardSQLQueryBuilder` and `MySQLQueryBuilder` implement step-by-step construction, and `QueryDirector` orchestrates predefined queries. The solution applies SOLID principles, improves readability, and makes SQL string generation testable.

## Discovered Tasks

| Task                                                                                     | Type     | Resolution                                                                                                              |
|------------------------------------------------------------------------------------------|----------|-------------------------------------------------------------------------------------------------------------------------|
| `// NOTE: Create differnt constructors` in original bad builder                           | NOTE     | Removed bad example; used Builder pattern with `StandardSQLQueryBuilder` and concrete constructors instead.            |
| `// ISSUE: Massive constructor with many optional parameters` and other inline comments    | ISSUE    | Eliminated telescoping constructor; encapsulated logic in builder methods.                                              |
| `// PROBLEMS WITH THIS APPROACH:` (duplicated inline logic, SRP, OCP, primitive obsession)  | PROBLEMS | Addressed all issues by separating concerns in builder, model, and director.                                            |

## Design Decisions and Patterns Used

- **Builder Pattern**: Step-by-step construction of `SQLQuery`.
- **Director Pattern**: `QueryDirector` centralizes query creation.
- **Clean Architecture**: Separation of concerns into Models, Interfaces, Services, Utils.
- **SOLID Principles**: SRP (each class has one responsibility), OCP (open for extension via concrete builders), LSP, ISP, DIP.
- **DRY**: No duplicated SQL string building code.

## UML Class Diagram

See [`uml/diagram.puml`](uml/diagram.puml) for the PlantUML diagram of classes and interfaces.