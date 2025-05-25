using ProblemSolving.Recursion;

namespace ProblemSolving.Tests;

public class ArrayMethodsTests
{
    [Fact]
    public void Sum_ReturnsZero_ForEmptyArray()
    {
        var result = ArrayMethods.Sum(Array.Empty<int>());
        Assert.Equal(0, result);
    }

    [Fact]
    public void Sum_CalculatesCorrectSum()
    {
        var numbers = new[] { 1, 2, 3, 4 };
        var result = ArrayMethods.Sum(numbers);
        Assert.Equal(10, result);
    }
}