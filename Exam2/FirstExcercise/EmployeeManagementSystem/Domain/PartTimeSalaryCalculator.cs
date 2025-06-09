namespace EmployeeManagementSystem;

public class PartTimeSalaryCalculator : ISalaryCalculator
{
  public decimal CalculateSalary(Employee employee) => employee.BaseSalary * 0.8m + employee.Bonus;
}