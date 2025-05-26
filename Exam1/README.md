# Exam 1

## How to present?

- You need to fork the entire project or update your fork
- Create a new branch named `exam1`
- You have to solve the exam in `CSharpCourse/Exam1/`
- Create a new console application here (it can be a single project since we don't need unit testing)

## What each solution should include?

- The name of the problem
- Why you chose the data structure

## Do you want to create a project using commands?

> You can go to the `SingleResponsibility` project there you have an example in the `README.md` file.

## Problems

### 1. Expression Evaluator with Undo

Description:

Build a simple calculator that supports:

1. EnterNumber(double x) and EnterOperator(char op) (where op is +, -, *, or /) to build up an infix expression.

2. Evaluate(): Compute and return the current result.

3. Undo(): Remove the last entered number or operator.

Users can chain operations (e.g. 5, +, 3, *, 2), then call Undo() multiple times to step back. After each change,
`Evaluate()` should reflect the current expression.

### 2. Print Server Load Balancer

Description:

A shared print server distributes incoming print tasks to multiple printers to keep them busy. You need to simulate the
assignment logic:

1. EnqueueJob(string jobId): A new print job arrives and is placed in the waiting line.

2. AssignNext(): Pull the next job from the front of the line and send it to the least-busy printer.

3. CompleteJob(string printerId, string jobId): The printer finishes its current job and becomes available again.

4. Status(): Report the list of waiting jobs in order and each printer’s current job (or idle).

Ensure that jobs are handled strictly in arrival order, and assignment always takes the oldest waiting job.

### 3. Browser History Navigation

Description:

Build a console app that simulates a web browser’s back and forward buttons. Users can:

1. Navigate to a new URL (e.g. go https://example.com)

2. Press “back” to return to the previous page (This can be a method)

3. Press “forward” to go forward again (only if they’ve gone back before) (this can be a method)

4. View their current page at any time

Your implementation should efficiently handle an arbitrary sequence of these commands and report the current URL after
each operation.

### 4. Single responsibility principle

Task

Refactor this ProcessOrders method so that each class has one responsibility (Fix any errors you find)

> Note: This runs itself you don't need to create an orchestator. Just split in single methods or classes (interfaces)

```csharp
public class OrderService
{
    private readonly List<Order> _processedOrders = new List<Order>();
    private readonly List<string> _logs = new List<string>();

    public void ProcessOrders()
    {
        // 1. Inline order data
        var orders = new List<Order>
        {
            new Order("A100", 2, 15.50m),
            new Order("B200", 1, 99.99m),
            new Order("C300", 5, 7.25m)
        };

        // 2. Validate each order
        foreach (var order in orders)
        {
            if (order.Quantity <= 0)
            {
                _logs.Add($"[{DateTime.UtcNow}] Invalid quantity for order {order.Id}");
                continue;
            }
            if (order.UnitPrice <= 0)
            {
                _logs.Add($"[{DateTime.UtcNow}] Invalid price for order {order.Id}");
                continue;
            }

            // 3. Compute total
            order.Total = order.Quantity * order.UnitPrice;

            // 4. Add to processed list
            _processedOrders.Add(order);

            // 5. Build report line
            var line = $"Order {order.Id}: {order.Quantity} × {order.UnitPrice:C} = {order.Total:C}";
            _logs.Add(line);
        }

        // 6. “Send” report by printing to console
        Console.WriteLine("---- Order Report ----");
        foreach (var log in _logs) Console.WriteLine(log);

        // 7. Clear logs for next run
        _logs.Clear();
    }
}

public record Order(
  string Id,
  int Quantity,
  decimal UnitPrice,
  decimal Total = 0
);

```