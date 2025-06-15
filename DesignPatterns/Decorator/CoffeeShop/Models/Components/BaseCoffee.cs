using System;
using System.Collections.Generic;
using CoffeeShop.Interfaces;
using CoffeeShop.Models;

namespace CoffeeShop.Models.Components;

/// <summary>
/// Base coffee component. Holds core properties of a coffee.
/// </summary>
public abstract class BaseCoffee : ICoffee
{
    private readonly List<Ingredient> _ingredients;
    private readonly string _description;
    private readonly decimal _baseCost;
    private readonly int _baseCalories;
    private readonly string _size;

    protected BaseCoffee(string description, decimal baseCost, int baseCalories, string size)
    {
        _description = description ?? throw new ArgumentNullException(nameof(description));
        _baseCost = baseCost;
        _baseCalories = baseCalories;
        _size = size ?? throw new ArgumentNullException(nameof(size));
        _ingredients = new List<Ingredient> { new Ingredient(description, baseCost, baseCalories) };
    }

    public virtual string GetDescription() => _description;
    public virtual decimal GetCost() => _baseCost;
    public virtual int GetCalories() => _baseCalories;
    public virtual string GetSize() => _size;

    public virtual List<Ingredient> GetIngredients() => new List<Ingredient>(_ingredients);
}