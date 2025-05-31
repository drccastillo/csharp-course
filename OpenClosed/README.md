# Open/Closed Principle (OCP)

## Definition

Software entities, classes, modules, functions, etc. **should be open for extension but closed for modification**. This means that you can add new behavior but cannot alter existing, tested code.
When we use the open/closed principle, we can add new functionality without changing the existing code.

## Scenario

A CLI that converts an in-memory product catalog into different export formats (JSON, CSV, XML, etc.). The first implementation will centralize all formats.

## Example (problem)

Every time that someone asks for new file type like: YAML, PDF. We must edit this class, risking regressions.

```csharp
using System.Text.Json;
using ProductExportApp.Models;

namespace ProductExportApp;

public class Exporter
{
  public string Export(IEnumerable<Product> products, FormatType format)
  {
    return format switch
    {
      FormatType.Json => ToJson(products),
      FormatType.Xml => ToXml(products),
      FormatType.Csv => ToCsv(products),
      _ => throw new NotSupportedException($"Format {format} is not supported.")
    };
  }

  private string ToJson(IEnumerable<Product> products)
  {
    return JsonSerializer.Serialize(products);
  }

  private string ToXml(IEnumerable<Product> products)
  {
    throw new NotImplementedException("XML serialization is not implemented yet.");
  }

  private string ToCsv(IEnumerable<Product> products)
  {
    throw new NotImplementedException("CSV serialization is not implemented yet.");
  }
}
```

## Example (solution)

With the solution the core application classes stay closed to change, yet we can extend with new exporters risk free.

## Summary

This implementation applies the Open/Closed Principle by introducing the `IProductExporter` abstraction and concrete exporters (`JsonExporter`, `CsvExporter`, `XmlExporter`, `YamlExporter`). A simple factory (`ExporterFactory`) selects the appropriate exporter based on `FormatType`, leveraging dependency injection and a lookup dictionary. The CLI (`ProductExportCli`) validates the format input and delegates the export operation to the factory.

### Implemented Tasks
| File                         | Task                                                   | Classification |
|------------------------------|--------------------------------------------------------|----------------|
| `Program.cs`                 | Register `YamlExporter` to support YAML format         | Required       |
| `Services/YamlExporter.cs`   | Added new exporter implementation for YAML             | Required       |
| `Cli/ProductExportCli.cs`    | Validate format input before export                    | Required       |
| `Tests/Services/TestCsvExporter.cs`       | Added tests for JSON and XML exporters                | Required       |
| `Tests/Services/TestExporterFactory.cs`   | Added test for custom exporter handling               | Required       |

### Design Decisions & Patterns
- **Strategy Pattern**: Exporters implement `IProductExporter` for interchangeable behaviors.
- **Factory Pattern**: `ExporterFactory` encapsulates exporter lookup based on `FormatType`.
- **Dependency Injection**: Services are registered and resolved via the DI container.
- **Open/Closed Principle**: New exporters can be added without modifying existing core code.

## UML Class Diagram

![UML Diagram](uml/diagram.puml)

