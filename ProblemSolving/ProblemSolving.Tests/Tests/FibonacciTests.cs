using ProblemSolving.Recursion;

namespace ProblemSolving.Tests;

public class FibonacciTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(6, 8)]
    public void GetFibonacci_ReturnsExpectedValue(int input, int expected)
    {
        var result = Fibonacci.GetFibonacci(input);
        Assert.Equal(expected, result);
    }
}