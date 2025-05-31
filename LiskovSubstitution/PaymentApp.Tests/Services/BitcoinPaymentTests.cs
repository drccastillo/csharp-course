using PaymentApp.Services;
using Xunit;

namespace PaymentApp.Tests.Services;

public class BitcoinPaymentTests
{
    [Fact]
    public void Charge_ValidArgs_WritesToConsole()
    {
        var payment = new BitcoinPayment();
        payment.Charge(100, "ref1");
    }

    [Theory]
    [InlineData(0, "ref")]
    [InlineData(-1, "ref")]
    [InlineData(10, "")]
    public void Charge_InvalidArgs_Throws(decimal amount, string reference)
    {
        var payment = new BitcoinPayment();
        Assert.Throws<ArgumentException>(() => payment.Charge(amount, reference));
    }
}
