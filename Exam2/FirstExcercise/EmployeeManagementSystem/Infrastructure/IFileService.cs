using System.Collections.Generic;

namespace EmployeeManagementSystem;

public interface IFileService
{
  void Save(string fileName, IEnumerable<Employee> employees);
  IEnumerable<Employee> Load(string fileName);
  void AppendLog(string fileName, string content);
}
