using ProblemSolving;

namespace ProblemSolving.Tests;

public class FindTheFirstRepeatedWordProblemTests
{
    [Fact]
    public void FindFirstRepeatedWord_ReturnsNull_WhenNoRepeats()
    {
        var input = "Every word is unique here.";
        var result = FindTheFirstRepeatedWordProblem.FindFirstRepeatedWord(input);
        Assert.Null(result);
    }

    [Fact]
    public void FindFirstRepeatedWord_ReturnsFirstRepeatedWord_CaseInsensitive()
    {
        var input = "This is a test for you, students, this is the best";
        var result = FindTheFirstRepeatedWordProblem.FindFirstRepeatedWord(input);
        Assert.Equal("this", result);
    }

    [Fact]
    public void FindFirstRepeatedWord_IgnoresPunctuation()
    {
        var input = "Hello! Hello, world.";
        var result = FindTheFirstRepeatedWordProblem.FindFirstRepeatedWord(input);
        Assert.Equal("hello", result);
    }

    [Fact]
    public void FindFirstRepeatedWord_HandlesEmptyString()
    {
        var result = FindTheFirstRepeatedWordProblem.FindFirstRepeatedWord("");
        Assert.Null(result);
    }

    [Fact]
    public void FindFirstRepeatedWord_HandlesNullInput()
    {
        var result = FindTheFirstRepeatedWordProblem.FindFirstRepeatedWord(null);
        Assert.Null(result);
    }
}
