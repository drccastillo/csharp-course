using Problem4.Domain.Models;

namespace Problem4.Domain.Interfaces;

public interface IOrderValidator
{
    bool IsValid(Order order);
    IEnumerable<string> GetValidationMessages(Order order);
}