using System.Text;
using ProductExportApp.Interfaces;
using ProductExportApp.Models;

namespace ProductExportApp.Services;

/// <summary>
/// Exports products in a simple YAML format.
/// </summary>
public class YamlExporter : IProductExporter
{
    public FormatType FormatKey => FormatType.Yaml;

    public string Export(IEnumerable<Product> products)
    {
        var sb = new StringBuilder();
        foreach (var product in products)
        {
            sb.AppendLine("- Product:");
            sb.AppendLine($"    Id: {product.Id}");
            sb.AppendLine($"    Name: {product.Name}");
            sb.AppendLine($"    Price: {product.Price}");
            sb.AppendLine($"    Category: {product.Category}");
        }
        return sb.ToString();
    }
}