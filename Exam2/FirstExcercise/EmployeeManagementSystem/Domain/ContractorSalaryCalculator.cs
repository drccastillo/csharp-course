namespace EmployeeManagementSystem;

public class ContractorSalaryCalculator : ISalaryCalculator
{
  public decimal CalculateSalary(Employee employee) => employee.BaseSalary;
}