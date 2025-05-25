using Problem2.Domain.Interfaces;
using Problem2.Domain.Models;

namespace Problem2.Infrastructure;

public class PrintRepository : IPrintRepository
{
    public Queue<PrintJob> WaitingJobs { get; } = new();
    public Dictionary<string, PrintJob?> Printers { get; } =
        new() { { "Printer1", null }, { "Printer2", null } };
}