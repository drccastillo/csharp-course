using ProblemSolving.Recursion;

namespace ProblemSolving.Tests;

public class FactorialTests
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(5, 120)]
    public void SolveFactorial_ReturnsExpectedResult(int input, int expected)
    {
        var result = Factorial.SolveFactorial(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SolveFactorial_ThrowsArgumentException_OnNegativeInput()
    {
        Assert.Throws<ArgumentException>(() => Factorial.SolveFactorial(-1));
    }
}