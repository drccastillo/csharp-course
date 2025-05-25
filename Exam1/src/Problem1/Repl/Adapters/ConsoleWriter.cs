using Problem1.Repl.Interfaces;

namespace Problem1.Repl.Adapters;

public class ConsoleWriter : IConsoleWriter
{
    public void WriteLine(string message) => Console.WriteLine(message);
    public void WritePrompt(string prompt = "> ") => Console.Write(prompt);
}