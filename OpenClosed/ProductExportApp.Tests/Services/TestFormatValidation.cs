using ProductExportApp.Models;
using ProductExportApp.Services;
using ProductExportApp.Interfaces;
using Xunit;

namespace ProductExportApp.Tests.Services;

public class TestFormatValidation
{
    private static readonly Product[] _products =
    [
        new Product(1, "Laptop", 7999.99m, "Electronics"),
        new Product(2, "Desk", 4999.99m, "Furniture"),
        new Product(3, "Fork", 2999.99m, "Kitchen"),
    ];

    [Fact]
    public void TryParseFormat_ValidFormats_ReturnsTrue()
    {
        var exporters = new IProductExporter[] { new CsvExporter(), new JsonExporter(), new XmlExporter(), new YamlExporter() };
        var validation = new FormatValidation(exporters);
        foreach (var format in new[] { "csv", "json", "xml", "yaml" })
        {
            var result = validation.TryParseFormat(format, out var type);
            Assert.True(result);
            Assert.Equal(format, type.ToString().ToLower());
        }
    }

    [Fact]
    public void TryParseFormat_InvalidFormat_ReturnsFalse()
    {
        var exporters = new IProductExporter[] { new CsvExporter(), new JsonExporter(), new XmlExporter(), new YamlExporter() };
        var validation = new FormatValidation(exporters);
        var result = validation.TryParseFormat("pdf", out var type);
        Assert.False(result);
    }

    [Fact]
    public void GetSupportedFormats_ReturnsAllRegisteredFormats()
    {
        var exporters = new IProductExporter[] { new CsvExporter(), new JsonExporter(), new XmlExporter(), new YamlExporter() };
        var validation = new FormatValidation(exporters);
        var supported = validation.GetSupportedFormats();
        Assert.Contains("csv", supported);
        Assert.Contains("json", supported);
        Assert.Contains("xml", supported);
        Assert.Contains("yaml", supported);
    }
}
