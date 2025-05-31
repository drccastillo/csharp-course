using ProductExportApp.Interfaces;
using ProductExportApp.Models;

namespace ProductExportApp.Cli;

public class ProductExportCli(IExporterFactory exporterFactory, IFormatValidation formatValidation)
{
  private readonly IExporterFactory _exporterFactory = exporterFactory;
  private readonly IFormatValidation _formatValidation = formatValidation;

  public void Run(string[] args)
  {
    var formatInput = args.FirstOrDefault() ?? "json";
    if (!_formatValidation.TryParseFormat(formatInput, out var format))
    {
        Console.WriteLine($"Invalid format '{formatInput}'. Supported formats: {string.Join(", ", _formatValidation.GetSupportedFormats())}");
        return;
    }

    var products = SampleData();
    var output = _exporterFactory.Export(products, format);
    Console.WriteLine(output);
  }

  private static IEnumerable<Product> SampleData() => new[]
  {
    new Product(1, "Laptop", 7999.99m, "Electronics"),
    new Product(2, "Desk", 4999.99m, "Furniture"),
    new Product(3, "Fork", 2999.99m, "Kitchen"),
  };
}