namespace CoffeeShop.Models.Components;

// Concrete Component - Different Types of base coffee
/// <summary>
/// Concrete Component: Americano base coffee.
/// </summary>
public class Americano : BaseCoffee
{
    public Americano() : base("Americano", 3.00m, 10, "Medium") { }
}