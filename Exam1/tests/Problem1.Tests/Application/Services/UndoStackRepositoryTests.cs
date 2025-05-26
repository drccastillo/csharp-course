using Problem1.Infrastructure.Repositories;
using Problem1.Domain.Models;

public class UndoStackRepositoryTests
{
    [Fact]
    public void PushAndPop_WorksCorrectly()
    {
        var repo = new UndoStackRepository();
        var t1 = new NumberToken(1);
        var t2 = new OperatorToken('+');
        repo.Push(t1);
        repo.Push(t2);
        Assert.Equal(t2, repo.Pop());
        Assert.Equal(t1, repo.Pop());
        Assert.Null(repo.Pop());
    }

    [Fact]
    public void GetStack_ReturnsTokensInOrder()
    {
        var repo = new UndoStackRepository();
        repo.Push(new NumberToken(1));
        repo.Push(new OperatorToken('+'));
        repo.Push(new NumberToken(2));
        var stack = repo.GetStack();
        Assert.Equal(new Token[] { new NumberToken(1), new OperatorToken('+'), new NumberToken(2) }, stack);
    }

    [Fact]
    public void Clear_RemovesAllTokens()
    {
        var repo = new UndoStackRepository();
        repo.Push(new NumberToken(1));
        repo.Clear();
        Assert.Empty(repo.GetStack());
    }

    [Fact]
    public void Pop_FromEmptyStack_ReturnsNull()
    {
        var repo = new UndoStackRepository();
        Assert.Null(repo.Pop());
    }

    [Fact]
    public void GetStack_ReturnsCopy_NotReference()
    {
        var repo = new UndoStackRepository();
        repo.Push(new NumberToken(1));
        var stack1 = repo.GetStack();

        repo.Push(new NumberToken(2));
        var stack2 = repo.GetStack();
        Assert.NotEqual(stack1.Count, stack2.Count);
    }

    [Fact]
    public void MixedOperations_StackOrderIsCorrect()
    {
        var repo = new UndoStackRepository();
        repo.Push(new NumberToken(1));
        repo.Push(new OperatorToken('+'));
        repo.Pop(); // removes '+'
        repo.Push(new OperatorToken('-'));
        var stack = repo.GetStack();
        Assert.Equal(new Token[] { new NumberToken(1), new OperatorToken('-') }, stack);
    }
}
