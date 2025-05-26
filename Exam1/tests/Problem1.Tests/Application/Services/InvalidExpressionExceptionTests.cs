using Problem1.Domain.Exceptions;

public class InvalidExpressionExceptionTests
{
    [Fact]
    public void DefaultConstructor_CreatesException()
    {
        var ex = new InvalidExpressionException();
        Assert.NotNull(ex);
        Assert.False(string.IsNullOrEmpty(ex.Message));
        Assert.Contains("InvalidExpressionException", ex.Message);
    }

    [Fact]
    public void MessageConstructor_SetsMessage()
    {
        var ex = new InvalidExpressionException("msg");
        Assert.Equal("msg", ex.Message);
    }

    [Fact]
    public void InnerExceptionConstructor_SetsProperties()
    {
        var inner = new Exception("inner");
        var ex = new InvalidExpressionException("outer", inner);
        Assert.Equal("outer", ex.Message);
        Assert.Equal(inner, ex.InnerException);
    }
}
