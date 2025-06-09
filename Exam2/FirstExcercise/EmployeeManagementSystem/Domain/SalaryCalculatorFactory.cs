namespace EmployeeManagementSystem;

public static class SalaryCalculatorFactory
{
  public static ISalaryCalculator GetCalculator(EmployeeType type) =>
    type switch
    {
      EmployeeType.FullTime => new FullTimeSalaryCalculator(),
      EmployeeType.PartTime => new PartTimeSalaryCalculator(),
      EmployeeType.Contractor => new ContractorSalaryCalculator(),
      _ => throw new NotSupportedException($"Unknown EmployeeType: {type}")
    };
}