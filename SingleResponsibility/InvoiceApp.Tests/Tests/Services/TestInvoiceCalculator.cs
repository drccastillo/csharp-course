using InvoiceApp.Models;
using InvoiceApp.Services;

namespace InvoiceApp.Tests.Services;

public class TestInvoiceCalculator
{
    [Fact]
    public void Calculate_ReturnsZeroes_WhenNoInvoices()
    {
        var calculator = new InvoiceCalculator();
        var (total, average) = calculator.Calculate(Array.Empty<Invoice>());

        Assert.Equal(0, total);
        Assert.Equal(0, average);
    }

    [Fact]
    public void Calculate_ReturnsTotalAndAverage_WhenInvoicesProvided()
    {
        var calculator = new InvoiceCalculator();
        var invoices = new[]
        {
      new Invoice(1, "A", 100m, new(2025, 5, 1)),
      new Invoice(2, "B", 200m, new(2025, 5, 2)),
      new Invoice(3, "C", 300m, new(2025, 5, 3)),
    };

        var (total, average) = calculator.Calculate(invoices);

        Assert.Equal(600, total);
        Assert.Equal(200, average);
    }

    [Fact]
    public void Calculate_ThrowsArgumentNullException_WhenInvoicesNull()
    {
        var calculator = new InvoiceCalculator();
        Assert.Throws<ArgumentNullException>(() => calculator.Calculate(null!));
    }

    [Fact]
    public void Calculate_ReturnsCorrectSumAndAverage_WhenNegativeAmountsProvided()
    {
        var calculator = new InvoiceCalculator();
        var invoices = new[]
        {
      new Invoice(1, "A", -100m, new(2025, 5, 1)),
      new Invoice(2, "B", 200m, new(2025, 5, 2)),
    };

        var (total, average) = calculator.Calculate(invoices);

        Assert.Equal(100m, total);
        Assert.Equal(50m, average);
    }
}