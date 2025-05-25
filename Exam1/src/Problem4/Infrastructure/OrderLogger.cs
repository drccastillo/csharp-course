using Problem4.Domain.Interfaces;

namespace Problem4.Infrastructure;

public class OrderLogger : IOrderLogger
{
    private readonly List<string> _logs = new();

    public void Log(string message) => _logs.Add(message);

    public void Flush()
    {
        foreach (var log in _logs)
            Console.WriteLine(log);
        _logs.Clear();
    }
}