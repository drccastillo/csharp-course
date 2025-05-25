using Problem2.Domain.Models;

namespace Problem2.Domain.Interfaces;

public interface IPrintRepository
{
    Queue<PrintJob> WaitingJobs { get; }
    Dictionary<string, PrintJob?> Printers { get; }
}