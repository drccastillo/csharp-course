using Problem4.Domain.Models;

namespace Problem4.Domain.Interfaces;

public interface IOrderFormatter
{
    string Format(Order order);
}