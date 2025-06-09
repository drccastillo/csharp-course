using System;

namespace EmployeeManagementSystem;

public class ConsoleNotifier : INotifier
{
  public void Notify(string message) => Console.WriteLine(message);
}