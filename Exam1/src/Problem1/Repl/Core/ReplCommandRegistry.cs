using Problem1.Repl.Interfaces;

namespace Problem1.Repl.Core;

public class ReplCommandRegistry
{
    private readonly Dictionary<string, IReplCommand> _commands = new(StringComparer.OrdinalIgnoreCase);

    public void Register(IReplCommand command)
    {
        if (!_commands.ContainsKey(command.Name))
        {
            _commands.Add(command.Name, command);
        }
    }

    public bool TryResolve(string name, out IReplCommand? command)
    {
        return _commands.TryGetValue(name, out command);
    }

    public IEnumerable<IReplCommand> All() => _commands.Values;
}
