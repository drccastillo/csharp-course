namespace Problem1.Repl.Interfaces;

public interface IConsoleWriter
{
    void WriteLine(string message);
    void WritePrompt(string prompt = "> ");
}
