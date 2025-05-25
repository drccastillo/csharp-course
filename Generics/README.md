# Generics Homework

## Summary

This implementation demonstrates the use of C# generics to create reusable components:

- `Box<T>`: a container for a single item.
- `SafeBox<T>`: extends `Box<T>` with type constraints.
- `Calculator<T>`: a generic calculator for numeric types using constraints.
- `IRepository<T>`: interface for CRUD operations.
- `Printer<T>`: prints values generically.
- `Creator<T>`: demonstrates factory pattern for generic creation.

## Task Classification

No actionable comments (`// TODO` or `// OPTIONAL`) were found in this project.

## Design Decisions

- **Generic Type Constraints:** enforce valid operations on type parameters.
- **Factory Pattern:** in `Creator<T>` for decoupled object creation.

## UML Class Diagram (optional)

Provide a diagram in `uml/diagram.mmd` if needed.