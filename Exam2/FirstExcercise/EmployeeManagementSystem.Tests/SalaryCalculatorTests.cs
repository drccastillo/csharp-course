using Xunit;

namespace EmployeeManagementSystem.Tests;

public class SalaryCalculatorTests
{
  [Fact]
  public void FullTimeSalary_IsBasePlusBonus()
  {
    var employee = new Employee { BaseSalary = 5000, Bonus = 500 };
    var calc = new FullTimeSalaryCalculator();
    var result = calc.CalculateSalary(employee);
    Assert.Equal(5500, result);
  }

  [Fact]
  public void PartTimeSalary_Is80PercentBasePlusBonus()
  {
    var employee = new Employee { BaseSalary = 4000, Bonus = 200 };
    var calc = new PartTimeSalaryCalculator();
    var result = calc.CalculateSalary(employee);
    Assert.Equal(3400, result);
  }

  [Fact]
  public void ContractorSalary_IsBaseOnly()
  {
    var employee = new Employee { BaseSalary = 4500, Bonus = 999 };
    var calc = new ContractorSalaryCalculator();
    var result = calc.CalculateSalary(employee);
    Assert.Equal(4500, result);
  }
}
