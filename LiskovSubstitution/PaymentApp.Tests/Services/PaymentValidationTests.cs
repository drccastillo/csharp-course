using PaymentApp.Services;
using Xunit;

namespace PaymentApp.Tests.Services;

public class PaymentValidationTests
{
    [Theory]
    [InlineData("", 10, "ref")]
    [InlineData("method", 0, "ref")]
    [InlineData("method", -5, "ref")]
    [InlineData("method", 10, "")]
    public void ValidatePaymentArguments_InvalidInputs_Throws(string method, decimal amount, string reference)
    {
        Assert.Throws<ArgumentException>(() => PaymentValidation.ValidatePaymentArguments(method, amount, reference));
    }

    [Fact]
    public void ValidatePaymentArguments_ValidInputs_DoesNotThrow()
    {
        PaymentValidation.ValidatePaymentArguments("creditcard", 10, "ref");
        PaymentValidation.ValidatePaymentArguments("paypal", 1, "abc");
        PaymentValidation.ValidatePaymentArguments("bitcoin", 0.01m, "xyz");
    }
}
