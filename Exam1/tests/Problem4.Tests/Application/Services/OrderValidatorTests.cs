using Problem4.Infrastructure;
using Problem4.Domain.Models;

public class OrderValidatorTests
{
    private readonly OrderValidator _validator = new();

    [Fact]
    public void IsValid_ValidOrder_ReturnsTrue()
    {
        var order = new Order("A100", 1, 10m);
        Assert.True(_validator.IsValid(order));
    }

    [Theory]
    [InlineData(0, 10)]
    [InlineData(1, 0)]
    [InlineData(0, 0)]
    public void IsValid_InvalidOrders_ReturnsFalse(int qty, decimal price)
    {
        var order = new Order("X", qty, price);
        Assert.False(_validator.IsValid(order));
    }

    [Fact]
    public void GetValidationMessages_ReturnsCorrectMessages()
    {
        var order = new Order("B200", 0, 0);
        var messages = _validator.GetValidationMessages(order).ToList();

        Assert.Equal(2, messages.Count);
        Assert.Contains(messages, msg => msg.Contains("Invalid quantity"));
        Assert.Contains(messages, msg => msg.Contains("Invalid price"));
    }
    
    [Theory]
    [InlineData("A", 1, 1, true)]
    [InlineData("B", 0, 1, false)]
    [InlineData("C", 1, 0, false)]
    [InlineData("D", 0, 0, false)]
    public void IsValid_CoversAllBranches(string id, int qty, decimal price, bool expected)
    {
        var validator = new OrderValidator();
        var order = new Order(id, qty, price);
        Assert.Equal(expected, validator.IsValid(order));
    }

    [Fact]
    public void GetValidationMessages_ReturnsAllMessages()
    {
        var validator = new OrderValidator();
        var order = new Order("E", 0, 0);
        var messages = validator.GetValidationMessages(order);
        Assert.Contains(messages, m => m.Contains("Invalid quantity"));
        Assert.Contains(messages, m => m.Contains("Invalid price"));
    }

    [Fact]
    public void GetValidationMessages_ValidOrder_ReturnsEmpty()
    {
        var validator = new OrderValidator();
        var order = new Order("F", 1, 1);
        var messages = validator.GetValidationMessages(order);
        Assert.Empty(messages);
    }
}