using PaymentApp.Services;
using Xunit;

namespace PaymentApp.Tests.Services;

public class PayPalPaymentTests
{
    [Fact]
    public void Charge_ValidArgs_WritesToConsole()
    {
        var payment = new PayPalPayment();
        payment.Charge(100, "ref1");
    }

    [Fact]
    public void Refund_ValidArgs_WritesToConsole()
    {
        var payment = new PayPalPayment();
        payment.Refund(50, "ref2");
    }

    [Theory]
    [InlineData(0, "ref")]
    [InlineData(-1, "ref")]
    [InlineData(10, "")]
    public void Charge_InvalidArgs_Throws(decimal amount, string reference)
    {
        var payment = new PayPalPayment();
        Assert.Throws<ArgumentException>(() => payment.Charge(amount, reference));
    }

    [Theory]
    [InlineData(0, "ref")]
    [InlineData(-1, "ref")]
    [InlineData(10, "")]
    public void Refund_InvalidArgs_Throws(decimal amount, string reference)
    {
        var payment = new PayPalPayment();
        Assert.Throws<ArgumentException>(() => payment.Refund(amount, reference));
    }
}
