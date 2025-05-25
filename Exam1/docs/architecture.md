# ✅ Exam 1 Final Summary – Dev-Fundamentals-II (C# Advanced)

## 📘 Objective
You implemented all 4 problems using:

- Advanced OOP with Clean Architecture
- SOLID (SRP, OCP, LSP, ISP, DIP)
- 100% unit test coverage (xUnit)
- Clean Code principles (DRY, KISS, YAGNI)
- `Microsoft.Extensions.Hosting` for CLI/DI support

---

## 🗂️ Project Structure
```
csharp-course/
└── Exam1/
    ├── src/
    │   ├── Problem1/        # Expression Evaluator with Undo
    │   ├── Problem2/        # Print Server Load Balancer
    │   ├── Problem3/        # Browser History Navigation
    │   └── Problem4/        # SRP Refactor of Order Processor
    ├── tests/
    │   ├── Problem1.Tests/
    │   ├── Problem2.Tests/
    │   ├── Problem3.Tests/
    │   └── Problem4.Tests/
    ├── docs/
    │   ├── architecture.md
    │   └── exam-overview.md
    └── README.md            # Project-level summary
```

---

## ✅ Problem Highlights

### 🔹 Problem 1 – Expression Evaluator with Undo
- Used:
  - `Stack<Token>`: stores entered inputs
  - `Queue<Token>` + `Stack<OperatorToken>`: used in **Shunting Yard Algorithm**
  - `Stack<double>`: used to evaluate postfix expressions
- Hosted runner
- 100% test coverage for edge cases and invalid operations

### 🔹 Problem 2 – Print Server Load Balancer
- FIFO queue for jobs, idle-tracking via dictionary
- Logic ensures oldest job to least-busy printer
- Thorough test coverage of state transitions

### 🔹 Problem 3 – Browser History Navigation
- Dual-stack system to manage back/forward logic
- Robust navigation behavior and edge handling
- Simple CLI output with `Current()` call

### 🔹 Problem 4 – SRP Refactor
- Fully decoupled validation, formatting, and logging
- DI-configured orchestrator executes logic directly
- Comprehensive unit testing with deterministic output

---

## ✅ Testing Strategy
- 100% coverage across all problems using `xUnit`
- Followed Arrange–Act–Assert structure
- Covered both typical and boundary cases

---

## 🧠 Design Principles Applied
| Principle | Application |
|----------|-------------|
| SRP       | Each class has a single reason to change |
| OCP       | Logic is open for extension (e.g., new validators) |
| DIP       | Services depend on abstractions via interfaces |
| KISS      | Data structures chosen for clarity (Stack, Queue) |
| DRY       | No repeated logic or formatting patterns |

---

## 📌 Execution
Use `dotnet run --project src/ProblemX/ProblemX.csproj` for Problems 1–4.  
Problem 4 runs directly via `Program.cs`.

---

## 📝 References
- [Microsoft Docs – Dependency Injection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [Clean Architecture (Uncle Bob)](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html)
- [xUnit Testing Framework](https://xunit.net)
- [SOLID Principles](https://en.wikipedia.org/wiki/SOLID)
