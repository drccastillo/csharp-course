using System.Collections.Generic;
using Moq;
using Xunit;

namespace EmployeeManagementSystem.Tests;

public class EmployeeManagerTests
{
  private readonly Mock<IFileService> fileServiceMock = new();
  private readonly Mock<INotifier> notifierMock = new();

  [Fact]
  public void AddEmployee_ValidData_EmployeeIsAdded()
  {
    var manager = new EmployeeManager(fileServiceMock.Object, notifierMock.Object);
    manager.AddEmployee("Alice", "FullTime", 5000, 500);
    notifierMock.Verify(n => n.Notify("Employee Alice added successfully!"), Times.Once);
  }

  [Fact]
  public void AddEmployee_InvalidType_NotifiesError()
  {
    var manager = new EmployeeManager(fileServiceMock.Object, notifierMock.Object);
    manager.AddEmployee("Alice", "InvalidType", 4000, 0);
    notifierMock.Verify(n => n.Notify(It.Is<string>(s => s.Contains("Invalid employee type"))), Times.Once);
  }

  [Fact]
  public void SaveToFile_CallsFileService()
  {
    var manager = new EmployeeManager(fileServiceMock.Object, notifierMock.Object);
    manager.AddEmployee("Bob", "Contractor", 4000, 0);
    manager.SaveToFile("test.txt");
    fileServiceMock.Verify(f => f.Save("test.txt", It.IsAny<IEnumerable<Employee>>()), Times.Once);
  }

  [Fact]
  public void ProcessPayroll_AppendsLogAndNotifies()
  {
    var manager = new EmployeeManager(fileServiceMock.Object, notifierMock.Object);
    manager.AddEmployee("John", "FullTime", 5000, 500);
    manager.ProcessPayroll();
    notifierMock.Verify(n => n.Notify(It.Is<string>(msg => msg.Contains("Paying John"))), Times.Once);
    fileServiceMock.Verify(f => f.AppendLog("payroll_log.txt", It.IsAny<string>()), Times.Once);
  }
}