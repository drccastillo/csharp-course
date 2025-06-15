using System;
using CoffeeShop.Interfaces;
using CoffeeShop.Services.Decorator;

namespace CoffeeShop.Services.Builder;

/// <summary>
/// Builder for configuring coffee orders via decorators.
/// </summary>
public class CoffeeOrderBuilder
{
    private ICoffee _coffee;

    public CoffeeOrderBuilder(ICoffee baseCoffee)
    {
        _coffee = baseCoffee ?? throw new ArgumentNullException(nameof(baseCoffee));
    }

    public CoffeeOrderBuilder WithSize(string size)
    {
        _coffee = new SizeDecorator(_coffee, size);
        return this;
    }

    public CoffeeOrderBuilder WithMilk(string milkType = "Regular")
    {
        _coffee = new MilkDecorator(_coffee, milkType);
        return this;
    }

    public CoffeeOrderBuilder WithSugar(int packets = 1, string sugarType = "White")
    {
        _coffee = new SugarDecorator(_coffee, packets, sugarType);
        return this;
    }

    public ICoffee Build() => _coffee;
}