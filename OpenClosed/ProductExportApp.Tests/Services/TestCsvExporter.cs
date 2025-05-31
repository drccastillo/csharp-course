using ProductExportApp.Models;
using ProductExportApp.Services;

namespace ProductExportApp.Tests.Services;

public class TestCsvExporter
{
  private static readonly Product[] _products =
  [
    new Product(1, "Laptop", 7999.99m, "Electronics"),
    new Product(2, "Desk", 4999.99m, "Furniture"),
    new Product(3, "Fork", 2999.99m, "Kitchen"),
  ];

    [Fact]
    public void Export_ProducesCommaSeparatedValues()
    {
        var exporter = new CsvExporter();

        var result = exporter.Export(_products);

        var expected = $"""
        Id,Name,Price,Category
        1,Laptop,7999.99,Electronics
        2,Desk,4999.99,Furniture
        3,Fork,2999.99,Kitchen
        
        """;

        Assert.Equal(expected, result);
    }

    [Fact]
    public void JsonExporter_ProducesIndentedJson()
    {
        var exporter = new JsonExporter();

        var result = exporter.Export(_products);

        Assert.StartsWith("[", result.TrimStart());
        Assert.Contains(Environment.NewLine, result);
    }

    [Fact]
    public void XmlExporter_ProducesXmlElements()
    {
        var exporter = new XmlExporter();

        var result = exporter.Export(_products);

        Assert.Contains("<Products>", result);
        Assert.Contains("</Products>", result);
    }

    [Fact]
    public void YamlExporter_ProducesYamlFormat()
    {
        var exporter = new YamlExporter();
        var result = exporter.Export(_products);
        Assert.Contains("- Product:", result);
        Assert.Contains("Id: 1", result);
        Assert.Contains("Name: Laptop", result);
        Assert.Contains("Price: 7999.99", result);
        Assert.Contains("Category: Electronics", result);
    }
}