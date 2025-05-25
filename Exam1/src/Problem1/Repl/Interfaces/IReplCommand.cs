using System.Threading.Tasks;

namespace Problem1.Repl.Interfaces;

public interface IReplCommand
{
    string Name { get; }                // Command name (e.g., "evaluate")
    string Description { get; }         // For help text
    Task ExecuteAsync(string[] args);   // Command logic
}
