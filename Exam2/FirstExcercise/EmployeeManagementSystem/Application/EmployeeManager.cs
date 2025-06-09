using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem;

public class EmployeeManager
{
  private readonly List<Employee> employees = new();
  private readonly IFileService fileService;
  private readonly INotifier notifier;

  public EmployeeManager(IFileService fileService, INotifier notifier)
  {
    this.fileService = fileService;
    this.notifier = notifier;
  }

  public void AddEmployee(string name, string typeString, decimal baseSalary, decimal bonus)
  {
    if (!Enum.TryParse<EmployeeType>(typeString, out var type))
    {
      notifier.Notify($"Invalid employee type: {typeString}");
      return;
    }

    var employee = new Employee
    {
      Name = name,
      Type = type,
      BaseSalary = baseSalary,
      Bonus = bonus
    };

    employees.Add(employee);
    notifier.Notify($"Employee {name} added successfully!");
  }

  public void SaveToFile(string fileName)
  {
    try
    {
      fileService.Save(fileName, employees);
      notifier.Notify("Data saved successfully!");
    }
    catch (Exception ex)
    {
      notifier.Notify($"Error saving file: {ex.Message}");
    }
  }

  public void LoadFromFile(string fileName)
  {
    try
    {
      var loaded = fileService.Load(fileName);
      employees.AddRange(loaded);
    }
    catch (Exception ex)
    {
      notifier.Notify($"Error loading file: {ex.Message}");
    }
  }

  public void DisplayAllEmployees()
  {
    notifier.Notify("\n=== Employee List ===");

    foreach (var employee in employees)
    {
      var calculator = SalaryCalculatorFactory.GetCalculator(employee.Type);
      var salary = calculator.CalculateSalary(employee);
      notifier.Notify($"Name: {employee.Name}, Type: {employee.Type}, Salary: ${salary:F2}");
    }
  }

  public void ProcessPayroll()
  {
    notifier.Notify("\n=== Processing Payroll ===");

    decimal totalPayroll = 0;

    foreach (var employee in employees)
    {
      var calculator = SalaryCalculatorFactory.GetCalculator(employee.Type);
      var salary = calculator.CalculateSalary(employee);
      totalPayroll += salary;

      notifier.Notify($"Paying {employee.Name}: ${salary:F2}");
      fileService.AppendLog("payroll_log.txt", $"{DateTime.Now}: Paid {employee.Name} ${salary:F2}");
    }

    notifier.Notify($"Total Payroll: ${totalPayroll:F2}");
  }
}