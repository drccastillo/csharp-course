using Problem1.Domain.Models;

namespace Problem1.Domain.Interfaces;

public interface IUndoStackRepository
{
    void Push(Token token);
    Token? Pop();
    IReadOnlyList<Token> GetStack();
    void Clear();
}