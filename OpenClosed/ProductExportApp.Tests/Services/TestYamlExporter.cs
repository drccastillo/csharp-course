using ProductExportApp.Models;
using ProductExportApp.Services;
using Xunit;

namespace ProductExportApp.Tests.Services;

public class TestYamlExporter
{
    private static readonly Product[] _products =
    [
        new Product(1, "Laptop", 7999.99m, "Electronics"),
        new Product(2, "Desk", 4999.99m, "Furniture"),
        new Product(3, "Fork", 2999.99m, "Kitchen"),
    ];

    [Fact]
    public void Export_ProducesYamlFormat()
    {
        var exporter = new YamlExporter();
        var result = exporter.Export(_products);
        Assert.Contains("- Product:", result);
        Assert.Contains("Id: 1", result);
        Assert.Contains("Name: Laptop", result);
        Assert.Contains("Price: 7999.99", result);
        Assert.Contains("Category: Electronics", result);
        Assert.Contains("Id: 2", result);
        Assert.Contains("Name: Desk", result);
        Assert.Contains("Price: 4999.99", result);
        Assert.Contains("Category: Furniture", result);
        Assert.Contains("Id: 3", result);
        Assert.Contains("Name: Fork", result);
        Assert.Contains("Price: 2999.99", result);
        Assert.Contains("Category: Kitchen", result);
    }
}
