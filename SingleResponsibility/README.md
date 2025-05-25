# Single Responsibility Principle (SRP) – Concept & Implementation

## 📚 Definition

> A **class, module, function, or method** should have **one and only one reason to change**.  
This means it should be responsible for **only one specific concern**.

---

## 🎯 Objective

This project demonstrates the **Single Responsibility Principle** by building a **CLI tool** that receives a list of customer invoices (as a JSON string) and prints a report with totals and averages.

---

## ❌ Initial Problem (Monolithic Design)

A single class handles multiple unrelated concerns:

```csharp
// InvoiceProcessor.cs
public class InvoiceProcessor
{
  public void Run(string[] args)
  {
    // 1. Parse arguments
    // 2. Deserialize invoices
    // 3. Calculate totals & averages
    // 4. Format report
    // 5. Print to console
  }
}
```

⚠️ Any change in input, processing, formatting, or output would require modifying the same class — violating SRP and increasing coupling.

---

## ✅ Final Design (SRP Applied)

Responsibilities are split into separate components:

| Component               | Responsibility                      |
|------------------------|--------------------------------------|
| `InvoiceParser`        | Parses and deserializes JSON input   |
| `InvoiceValidator`     | Validates command-line arguments     |
| `InvoiceCalculator`    | Computes total and average amounts   |
| `AsciiReportFormatter` | Formats results into a printable form|
| `InvoiceCli`           | Coordinates the execution flow       |

🧩 These are wired together using **Dependency Injection** for modularity and testability.

---

## 🛠️ Project Setup

Run the following commands in a terminal (PowerShell/Linux):

```bash
# 1. Create solution and projects
mkdir SingleResponsibility && cd SingleResponsibility
dotnet new sln -n SingleResponsibility
dotnet new console -n InvoiceApp
dotnet new xunit -n InvoiceApp.Tests

# 2. Link projects to the solution
dotnet sln add InvoiceApp/InvoiceApp.csproj
dotnet sln add InvoiceApp.Tests/InvoiceApp.Tests.csproj
dotnet add InvoiceApp.Tests reference InvoiceApp

# 3. Add required packages
dotnet add InvoiceApp package Microsoft.Extensions.Hosting
dotnet add InvoiceApp package Microsoft.Extensions.DependencyInjection

# 4. Run application
dotnet run --project InvoiceApp

# 5. Run tests
dotnet test
```

---

## ✅ Task Classification

| File                       | Comment                                          | Classification |
|----------------------------|--------------------------------------------------|----------------|
| `InvoiceCli.cs`            | `// TODO: Create validator, create as a service` | Required       |
| `Program.cs`               | `// OPTIONAL: Create the diagram...`             | Optional       |
| `TestInvoiceCalculator.cs` | `// TODO: Add negative test cases`               | Optional       |

---

## 🧠 Design Decisions & Patterns

- **Single Responsibility Principle:** each class has one focused responsibility.
- **Dependency Injection (DI):** enables decoupling and easier testing.
- **Interface Segregation:** encourages clean abstraction for each responsibility.

---

## 📐 UML Class Diagram (Optional)

You may add a Mermaid diagram at:

```
uml/diagram.mmd
```

(Use `mmdc` to render to SVG or PNG.)
