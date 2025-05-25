using Problem4.Domain.Models;
using Problem4.Domain.Interfaces;

namespace Problem4.Infrastructure;

public class OrderValidator : IOrderValidator
{
    public bool IsValid(Order order) => order.Quantity > 0 && order.UnitPrice > 0;

    public IEnumerable<string> GetValidationMessages(Order order)
    {
        if (order.Quantity <= 0)
            yield return $"[{DateTime.UtcNow}] Invalid quantity for order {order.Id}";
        if (order.UnitPrice <= 0)
            yield return $"[{DateTime.UtcNow}] Invalid price for order {order.Id}";
    }
}