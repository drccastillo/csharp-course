namespace Problem3.Domain.Interfaces;

public interface IHistoryStore
{
    void Visit(string url);
    string? Back();
    string? Forward();
    string? Current();
}