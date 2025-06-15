namespace CoffeeShop.Models.Components;

// Concrete Component - Different Types of base coffee
/// <summary>
/// Concrete Component: Latte base coffee.
/// </summary>
public class Latte : BaseCoffee
{
    public Latte() : base("Latte", 4.80m, 200, "Medium") { }
}