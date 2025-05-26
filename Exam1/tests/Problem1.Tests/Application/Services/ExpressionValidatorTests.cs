using Problem1.Infrastructure.Validators;
using Problem1.Domain.Exceptions;
using Xunit;

public class ExpressionValidatorTests
{
    [Theory]
    [InlineData(1.0)]
    [InlineData(-100.5)]
    [InlineData(0.0)]
    public void ValidateNumber_ValidNumbers_DoesNotThrow(double value)
    {
        var validator = new ExpressionValidator();
        validator.ValidateNumber(value);
    }

    [Theory]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity)]
    public void ValidateNumber_InvalidNumbers_Throws(double value)
    {
        var validator = new ExpressionValidator();
        Assert.Throws<InvalidExpressionException>(() => validator.ValidateNumber(value));
    }

    [Theory]
    [InlineData('+')]
    [InlineData('-')]
    [InlineData('*')]
    [InlineData('/')]
    public void ValidateOperator_ValidOperators_DoesNotThrow(char op)
    {
        var validator = new ExpressionValidator();
        validator.ValidateOperator(op);
    }

    [Theory]
    [InlineData('%')]
    [InlineData('^')]
    [InlineData('a')]
    public void ValidateOperator_InvalidOperators_Throws(char op)
    {
        var validator = new ExpressionValidator();
        Assert.Throws<InvalidExpressionException>(() => validator.ValidateOperator(op));
    }
}
