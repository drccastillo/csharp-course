namespace Problem4.Domain.Interfaces;

public interface IOrderPrinter
{
    void PrintReport(IEnumerable<string> logs);
}
