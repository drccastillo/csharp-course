using Problem4.Infrastructure;
using Problem4.Domain.Models;

public class OrderFormatterTests
{
    [Fact]
    public void Format_ReturnsFormattedString()
    {
        var order = new Order("C300", 3, 20m);
        var formatter = new OrderFormatter();
        var result = formatter.Format(order);

        Assert.Contains("C300", result);
        Assert.Contains("3", result);
        Assert.Contains("20", result);
        Assert.Contains("60", result);
    }

    [Fact]
    public void Format_FormatsOrderWithCultureInvariant()
    {
        var order = new Problem4.Domain.Models.Order("X999", 3, 12.5m);
        var formatter = new OrderFormatter();
        var formatted = formatter.Format(order);

        Assert.Contains("X999", formatted);
        Assert.Contains("3", formatted);
        Assert.Contains("12.5", formatted, StringComparison.InvariantCulture);
        Assert.Contains("37.5", formatted, StringComparison.InvariantCulture);
    }

    [Fact]
    public void Format_HandlesZeroAndNegativeValues()
    {
        var order = new Problem4.Domain.Models.Order("NEG", -2, -10m);
        var formatter = new OrderFormatter();
        var formatted = formatter.Format(order);
        Assert.Contains("NEG", formatted);
        Assert.Contains("-2", formatted);

        var expectedUnitPrice = (-10m).ToString("C");
        var expectedTotal = (20m).ToString("C");
        Assert.Contains(expectedUnitPrice, formatted);
        Assert.Contains(expectedTotal, formatted);
    }
}
