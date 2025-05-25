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
}
