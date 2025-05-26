using InvoiceApp.Services;

namespace InvoiceApp.Tests.Services;

public class TestInvoiceValidator
{
    [Fact]
    public void Validate_Throws_WhenArgsNull()
    {
        var validator = new InvoiceValidator();
        string[]? args = null;
        Assert.Throws<ArgumentException>(() => validator.Validate(args));
    }

    [Fact]
    public void Validate_Throws_WhenArgsEmpty()
    {
        var validator = new InvoiceValidator();
        Assert.Throws<ArgumentException>(() => validator.Validate(Array.Empty<string>()));
    }

    [Fact]
    public void Validate_Throws_WhenFirstArgIsNullOrWhitespace()
    {
        var validator = new InvoiceValidator();
        Assert.Throws<ArgumentException>(() => validator.Validate(new[] { "   " }));
    }

    [Fact]
    public void Validate_DoesNotThrow_WhenValidArgs()
    {
        var validator = new InvoiceValidator();
        var args = new[] { "[ { \"Id\": 1, \"Customer\": \"A\", \"Amount\": 10, \"Date\": \"2025-05-25\" } ]" };
        validator.Validate(args);
    }
}
