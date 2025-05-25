using Problem1.Domain.Interfaces;
using Problem1.Domain.Models;

namespace Problem1.Infrastructure.Repositories;

public class UndoStackRepository : IUndoStackRepository
{
    private readonly Stack<Token> _tokens = new();

    public void Push(Token token) => _tokens.Push(token);
    public Token? Pop() => _tokens.Count > 0 ? _tokens.Pop() : null;
    public IReadOnlyList<Token> GetStack() => _tokens.Reverse().ToList();
    public void Clear() => _tokens.Clear();
}