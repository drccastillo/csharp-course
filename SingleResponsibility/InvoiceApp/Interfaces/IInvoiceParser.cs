using InvoiceApp.Models;

namespace InvoiceApp.Interfaces;

public interface IInvoiceParser
{
    IEnumerable<Invoice> Parse(string json);
}