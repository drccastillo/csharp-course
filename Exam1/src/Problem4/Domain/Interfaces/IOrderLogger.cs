namespace Problem4.Domain.Interfaces;

public interface IOrderLogger
{
    void Log(string message);
    void Flush();
}