namespace CoffeeShop.Models.Components;

// Concrete Component - Different Types of base coffee
/// <summary>
/// Concrete Component: Cappuccino base coffee.
/// </summary>
public class Cappuccino : BaseCoffee
{
    public Cappuccino() : base("Cappuccino", 4.00m, 120, "Medium") { }
}