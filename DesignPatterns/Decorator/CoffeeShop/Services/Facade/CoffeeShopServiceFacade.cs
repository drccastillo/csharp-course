using System;
using System.Collections.Generic;
using System.Linq;
using CoffeeShop.Interfaces;
using CoffeeShop.Models;
using CoffeeShop.Models.Components;

namespace CoffeeShop.Services.Facade;

public class CoffeeShopServiceFacade
{
  private readonly Dictionary<string, Func<ICoffee>> _baseCoffees = new()
  {
    { "Espresso", () => new Espresso() },
    { "Americano", () => new Americano() },
    { "Latte", () => new Latte() },
    { "Mocha", () => new Mocha() },
    { "Cappuccino", () => new Cappuccino() }
  };

  public void ShowMenu()
  {
    Console.WriteLine("Coffee shop Menu");
    Console.WriteLine("Base coffees: ");

    foreach (var baseCoffee in _baseCoffees)
    {
      var cofee = baseCoffee.Value();
      Console.WriteLine($"""
      {baseCoffee.Key}: ${cofee.GetCost():F2} ({cofee.GetCalories()} calories)
      """);
    }

    Console.WriteLine("\nAvailable Add ons:");
    Console.WriteLine(" Milk (Regular/Soy/Coconut): $0.60-$0.90");
    Console.WriteLine(" Sugar (White/Brown/Stevia): $0.30-$0.60 per packet");
  }

    public ICoffee CreateCustomCoffee(string baseCoffeeType)
  {
    var coffeeCreator = _baseCoffees.FirstOrDefault(baseCoffee =>
      baseCoffee.Key == baseCoffeeType).Value ?? throw new ArgumentNullException(nameof(baseCoffeeType));

    return coffeeCreator();
  }

    /// <summary>
    /// Prints a detailed receipt for the given coffee order.
    /// </summary>
    public void PrintReceipt(ICoffee coffee)
    {
        if (coffee == null) throw new ArgumentNullException(nameof(coffee));

        Console.WriteLine("\n----- Coffee Receipt -----");
        Console.WriteLine($"Order: {coffee.GetDescription()}");
        Console.WriteLine($"Size: {coffee.GetSize()}");
        Console.WriteLine($"Total Cost: {coffee.GetCost():C2}");
        Console.WriteLine($"Total Calories: {coffee.GetCalories()}\n");
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in coffee.GetIngredients())
        {
            Console.WriteLine($" - {ingredient.Name}: Cost {ingredient.Cost:C2}, Calories {ingredient.Calories}");
        }
        Console.WriteLine("--------------------------\n");
    }
}