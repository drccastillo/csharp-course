namespace EmployeeManagementSystem.Cli;

public class Runner
{
  private readonly EmployeeManager manager;

  public Runner(EmployeeManager manager)
  {
    this.manager = manager;
  }

  public void Run(string[] args)
  {
    foreach (var arg in args)
    {
      var parts = arg.Split(',');
      if (parts.Length == 4 &&
          decimal.TryParse(parts[2], out var baseSalary) &&
          decimal.TryParse(parts[3], out var bonus))
      {
        manager.AddEmployee(parts[0], parts[1], baseSalary, bonus);
      }
    }

    manager.DisplayAllEmployees();
    manager.ProcessPayroll();
    manager.SaveToFile("employees.txt");
  }
}