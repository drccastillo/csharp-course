using InvoiceApp.Models;

namespace InvoiceApp.Interfaces;

public interface IInvoiceCalculator
{
    (decimal total, decimal average) Calculate(IEnumerable<Invoice> invoices);
}