using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeeManagementSystem;

public class TextFileService : IFileService
{
  public void Save(string fileName, IEnumerable<Employee> employees)
  {
    using var writer = new StreamWriter(fileName);
    foreach (var emp in employees)
    {
      writer.WriteLine($"{emp.Name},{emp.Type},{emp.BaseSalary},{emp.Bonus}");
    }
  }

  public IEnumerable<Employee> Load(string fileName)
  {
    var result = new List<Employee>();
    if (!File.Exists(fileName)) return result;

    var lines = File.ReadAllLines(fileName);
    foreach (var line in lines)
    {
      var parts = line.Split(',');
      if (parts.Length == 4 &&
          Enum.TryParse<EmployeeType>(parts[1], out var type) &&
          decimal.TryParse(parts[2], out var baseSalary) &&
          decimal.TryParse(parts[3], out var bonus))
      {
        result.Add(new Employee
        {
          Name = parts[0],
          Type = type,
          BaseSalary = baseSalary,
          Bonus = bonus
        });
      }
    }
    return result;
  }

  public void AppendLog(string fileName, string content)
  {
    File.AppendAllText(fileName, content + Environment.NewLine);
  }
}