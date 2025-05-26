using System.Text.Json;
using InvoiceApp.Interfaces;
using InvoiceApp.Models;

namespace InvoiceApp.Services;

public class InvoiceParser : IInvoiceParser
{
    public IEnumerable<Invoice> Parse(string json)
    {
        return JsonSerializer.Deserialize<List<Invoice>>(json)!
          ?? Enumerable.Empty<Invoice>();
    }
}