using InvoiceApp.Interfaces;
using InvoiceApp.Models;

namespace InvoiceApp.Services;

public class InvoiceCalculator : IInvoiceCalculator
{
  public (decimal total, decimal average) Calculate(IEnumerable<Invoice> invoices)
  {
    if (invoices is null)
        throw new ArgumentNullException(nameof(invoices));

    var list = invoices.ToList();

    if (list.Count == 0)
    {
      return (0, 0);
    }

    var total = list.Sum(i => i.Amount);
    var average = list.Average(i => i.Amount);

    return (total, average);
  }
}