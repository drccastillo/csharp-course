using ProductExportApp.Interfaces;
using ProductExportApp.Models;

namespace ProductExportApp.Services;

public class FormatValidation : IFormatValidation
{
    private readonly Dictionary<string, FormatType> _formatMap;

    public FormatValidation(IEnumerable<IProductExporter> exporters)
    {
        _formatMap = exporters
            .Select(e => e.FormatKey)
            .Distinct()
            .ToDictionary(
                f => f.ToString().ToLower(),
                f => f
            );
    }

    public bool TryParseFormat(string input, out FormatType formatType)
    {
        if (input == null)
        {
            formatType = default;
            return false;
        }
        return _formatMap.TryGetValue(input.ToLower(), out formatType);
    }

    public IEnumerable<string> GetSupportedFormats() => _formatMap.Keys;
}
