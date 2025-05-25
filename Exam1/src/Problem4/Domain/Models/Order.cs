namespace Problem4.Domain.Models;

public class Order
{
    public string Id { get; }
    public int Quantity { get; }
    public decimal UnitPrice { get; }
    public decimal Total => Quantity * UnitPrice;

    public Order(string id, int quantity, decimal unitPrice)
    {
        Id = id;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}