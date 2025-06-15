namespace CoffeeShop.Models.Components;

// Concrete Component - Different Types of base coffee
/// <summary>
/// Concrete Component: Mocha base coffee.
/// </summary>
public class Mocha : BaseCoffee
{
    public Mocha() : base("Mocha", 5.00m, 300, "Medium") { }
}