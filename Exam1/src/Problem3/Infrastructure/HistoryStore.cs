using Problem3.Domain.Interfaces;

namespace Problem3.Infrastructure;

public class HistoryStore : IHistoryStore
{
    private readonly Stack<string> _backStack = new();
    private readonly Stack<string> _forwardStack = new();
    private string? _current;

    public void Visit(string url)
    {
        if (_current != null)
            _backStack.Push(_current);
        _current = url;
        _forwardStack.Clear();
    }

    public string? Back()
    {
        if (_backStack.Count == 0) return _current;
        _forwardStack.Push(_current!);
        _current = _backStack.Pop();
        return _current;
    }

    public string? Forward()
    {
        if (_forwardStack.Count == 0) return _current;
        _backStack.Push(_current!);
        _current = _forwardStack.Pop();
        return _current;
    }

    public string? Current() => _current;
}