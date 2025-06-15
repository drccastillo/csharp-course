using CoffeeShop.Models;

namespace CoffeeShop.Interfaces;

/// <summary>
/// Component interface for base coffee and decorators.
/// </summary>
public interface ICoffee
{
    string GetDescription();
    decimal GetCost();
    int GetCalories();
    string GetSize();
    List<Ingredient> GetIngredients();
}