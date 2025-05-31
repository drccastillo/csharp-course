using ProductExportApp.Models;

namespace ProductExportApp.Interfaces;

public interface IFormatValidation
{
    bool TryParseFormat(string input, out FormatType formatType);
    IEnumerable<string> GetSupportedFormats();
}
