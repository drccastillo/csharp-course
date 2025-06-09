namespace EmployeeManagementSystem;

public class FullTimeSalaryCalculator : ISalaryCalculator
{
  public decimal CalculateSalary(Employee employee) => employee.BaseSalary + employee.Bonus;
}
