using Problem1.Domain.Models;

public class TokenTests
{
    [Fact]
    public void NumberToken_StoresValue()
    {
        var token = new NumberToken(42.5);
        Assert.Equal(42.5, token.Value);
    }

    [Fact]
    public void OperatorToken_StoresSymbol()
    {
        var token = new OperatorToken('+');
        Assert.Equal('+', token.Symbol);
    }

    [Fact]
    public void Token_Equality_WorksForSameValues()
    {
        var t1 = new NumberToken(1.1);
        var t2 = new NumberToken(1.1);
        Assert.Equal(t1, t2);
        var o1 = new OperatorToken('-');
        var o2 = new OperatorToken('-');
        Assert.Equal(o1, o2);
    }

    [Fact]
    public void Token_Equality_DiffersForDifferentValues()
    {
        var t1 = new NumberToken(1.1);
        var t2 = new NumberToken(2.2);
        Assert.NotEqual(t1, t2);
        var o1 = new OperatorToken('-');
        var o2 = new OperatorToken('+');
        Assert.NotEqual(o1, o2);
    }

    [Fact]
    public void Token_Equality_DiffersForDifferentTypes()
    {
        var number = new NumberToken(5);
        var op = new OperatorToken('5');
        Assert.False(number.Equals(op));
    }

    [Fact]
    public void Token_Equality_WithNull_ReturnsFalse()
    {
        var number = new NumberToken(5);
        Assert.False(number.Equals(null));
        var op = new OperatorToken('+');
        Assert.False(op.Equals(null));
    }

    [Fact]
    public void Token_GetHashCode_EqualTokens_SameHash()
    {
        var t1 = new NumberToken(3.14);
        var t2 = new NumberToken(3.14);
        Assert.Equal(t1.GetHashCode(), t2.GetHashCode());
        var o1 = new OperatorToken('*');
        var o2 = new OperatorToken('*');
        Assert.Equal(o1.GetHashCode(), o2.GetHashCode());
    }

    [Fact]
    public void Token_GetHashCode_DifferentTokens_DifferentHash()
    {
        var t1 = new NumberToken(1);
        var t2 = new NumberToken(2);
        Assert.NotEqual(t1.GetHashCode(), t2.GetHashCode());
        var o1 = new OperatorToken('+');
        var o2 = new OperatorToken('-');
        Assert.NotEqual(o1.GetHashCode(), o2.GetHashCode());
    }
}
