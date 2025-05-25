using Problem4.Domain.Models;
using Problem4.Domain.Interfaces;

namespace Problem4.Infrastructure;

public class OrderFormatter : IOrderFormatter
{
    public string Format(Order order) =>
        $"Order {order.Id}: {order.Quantity} × {order.UnitPrice:C} = {order.Total:C}";
}
