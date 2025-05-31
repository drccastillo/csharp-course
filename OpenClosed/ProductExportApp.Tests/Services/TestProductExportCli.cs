using ProductExportApp.Cli;
using ProductExportApp.Interfaces;
using ProductExportApp.Models;
using ProductExportApp.Services;
using Xunit;
using System.IO;

namespace ProductExportApp.Tests.Services;

public class TestProductExportCli
{
    private static readonly Product[] _products =
    [
        new Product(1, "Laptop", 7999.99m, "Electronics"),
        new Product(2, "Desk", 4999.99m, "Furniture"),
        new Product(3, "Fork", 2999.99m, "Kitchen"),
    ];

    private ProductExportCli CreateCli()
    {
        var exporters = new IProductExporter[] { new CsvExporter(), new JsonExporter(), new XmlExporter(), new YamlExporter() };
        var factory = new ExporterFactory(exporters);
        var validation = new FormatValidation(exporters);
        return new ProductExportCli(factory, validation);
    }

    [Fact]
    public void Run_ValidFormat_PrintsExportedData()
    {
        var cli = CreateCli();
        using var sw = new StringWriter();
        Console.SetOut(sw);
        cli.Run(new[] { "csv" });
        var output = sw.ToString();
        Assert.Contains("Id,Name,Price,Category", output);
        Assert.Contains("Laptop", output);
    }

    [Fact]
    public void Run_InvalidFormat_PrintsError()
    {
        var cli = CreateCli();
        using var sw = new StringWriter();
        Console.SetOut(sw);
        cli.Run(new[] { "pdf" });
        var output = sw.ToString();
        Assert.Contains("Invalid format", output);
        Assert.Contains("csv", output);
        Assert.Contains("json", output);
        Assert.Contains("xml", output);
        Assert.Contains("yaml", output);
    }

    [Fact]
    public void Run_NoArgs_DefaultsToJson()
    {
        var cli = CreateCli();
        using var sw = new StringWriter();
        Console.SetOut(sw);
        cli.Run(Array.Empty<string>());
        var output = sw.ToString();
        Assert.Contains("[", output);
        Assert.Contains("Laptop", output);
    }
}
