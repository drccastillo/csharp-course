using ProductExportApp.Interfaces;
using ProductExportApp.Models;
using ProductExportApp.Services;

namespace ProductExportApp.Tests.Services;

public class TestExporterFactory
{
    [Fact]
    public void ExporterFactory_CanHandleCustomExporter()
    {
        var products = new[]
        {
            new Product(1, "Laptop", 7999.99m, "Electronics"),
            new Product(2, "Desk", 4999.99m, "Furniture"),
            new Product(3, "Fork", 2999.99m, "Kitchen"),
        };

        var yamlExporter = new YamlExporter();
        var factory = new ExporterFactory(new IProductExporter[] { yamlExporter });
        var result = factory.Export(products, FormatType.Yaml);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public void Export_ThrowsForUnsupportedFormat()
    {
        var factory = new ExporterFactory(new IProductExporter[] { new CsvExporter() });
        var products = new[] { new Product(1, "Laptop", 7999.99m, "Electronics") };
        Assert.Throws<NotSupportedException>(() => factory.Export(products, FormatType.Yaml));
    }
}
