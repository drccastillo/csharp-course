using System.Text;
using InvoiceApp.Interfaces;
using InvoiceApp.Models;

namespace InvoiceApp.Services;

public class AsciiReportFormatter : IReportFormatter
{
    public string Format(IEnumerable<Invoice> invoices, decimal total, decimal average)
    {
        var report = new StringBuilder();
        report.AppendLine("ID | Customer | Amount | Date");
        report.AppendLine("---|----------|--------|------");

        foreach (var invoice in invoices)
        {
            report.AppendLine($"{invoice.Id} | {invoice.Customer} | {invoice.Amount} | {invoice.Date}");
        }

        report.AppendLine($"Total: {total}");
        report.AppendLine($"Average: {average}");

        return report.ToString();
    }
}