using InvoiceApp.Models;
using InvoiceApp.Services;

namespace InvoiceApp.Tests.Services;

public class TestAsciiReportFormatter
{
    [Fact]
    public void Format_ReturnsExpectedReport()
    {
        var formatter = new AsciiReportFormatter();
        var invoices = new[]
        {
            new Invoice(1, "A", 100m, new(2025, 5, 1)),
            new Invoice(2, "B", 200m, new(2025, 5, 2)),
        };
        var report = formatter.Format(invoices, 300m, 150m);
        Assert.Contains("ID | Customer | Amount | Date", report);
        Assert.Contains("1 | A | 100", report);
        Assert.Contains("2 | B | 200", report);
        Assert.Contains("Total: 300", report);
        Assert.Contains("Average: 150", report);
    }

    [Fact]
    public void Format_ReturnsHeaderAndTotals_WhenNoInvoices()
    {
        var formatter = new AsciiReportFormatter();
        var report = formatter.Format(Array.Empty<Invoice>(), 0, 0);
        Assert.Contains("ID | Customer | Amount | Date", report);
        Assert.Contains("Total: 0", report);
        Assert.Contains("Average: 0", report);
    }
}
