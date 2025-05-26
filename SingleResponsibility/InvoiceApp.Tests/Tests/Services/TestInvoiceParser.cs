using InvoiceApp.Models;
using InvoiceApp.Services;

namespace InvoiceApp.Tests.Services;

public class TestInvoiceParser
{
    [Fact]
    public void Parse_ReturnsInvoices_WhenValidJson()
    {
        var parser = new InvoiceParser();
        var json = "[ { \"Id\": 1, \"Customer\": \"A\", \"Amount\": 10, \"Date\": \"2025-05-25\" } ]";
        var result = parser.Parse(json).ToList();
        Assert.Single(result);
        Assert.Equal(1, result[0].Id);
        Assert.Equal("A", result[0].Customer);
        Assert.Equal(10, result[0].Amount);
    }

    [Fact]
    public void Parse_ReturnsEmpty_WhenEmptyJsonArray()
    {
        var parser = new InvoiceParser();
        var result = parser.Parse("[]");
        Assert.Empty(result);
    }

    [Fact]
    public void Parse_Throws_WhenInvalidJson()
    {
        var parser = new InvoiceParser();
        Assert.ThrowsAny<System.Text.Json.JsonException>(() => parser.Parse("not a json"));
    }
}
