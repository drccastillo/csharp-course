using System;
using System.Collections.Generic;
using CoffeeShop.Interfaces;
using CoffeeShop.Models;

namespace CoffeeShop.Services.Decorator;

/// <summary>
/// Base decorator: wraps an ICoffee component.
/// </summary>
public abstract class CoffeeDecorator : ICoffee
{
    protected readonly ICoffee _coffee;

    protected CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee ?? throw new ArgumentNullException(nameof(coffee));
    }

    public virtual string GetDescription() => _coffee.GetDescription();
    public virtual decimal GetCost() => _coffee.GetCost();
    public virtual int GetCalories() => _coffee.GetCalories();
    public virtual string GetSize() => _coffee.GetSize();

    public virtual List<Ingredient> GetIngredients() => new List<Ingredient>(_coffee.GetIngredients());
}