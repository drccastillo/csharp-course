using CoffeeShop.Interfaces;
using CoffeeShop.Models;
using CoffeeShop.Models.Components;
using CoffeeShop.Services.Decorator;
using Xunit;

namespace CoffeeShop.Tests.Services
{
    public class MilkDecoratorTests
    {
        [Fact]
        public void GetCost_AddsMilkCost()
        {
            ICoffee espresso = new Espresso();
            var decorated = new MilkDecorator(espresso, "Soy");
            Assert.Equal(espresso.GetCost() + 0.75m, decorated.GetCost());
        }

        [Fact]
        public void GetCalories_AddsMilkCalories()
        {
            ICoffee espresso = new Espresso();
            var decorated = new MilkDecorator(espresso, "Coconut");
            Assert.Equal(espresso.GetCalories() + 70, decorated.GetCalories());
        }

        [Fact]
        public void GetIngredients_IncludesMilkIngredient()
        {
            ICoffee espresso = new Espresso();
            var decorated = new MilkDecorator(espresso, "Regular");
            var ingredients = decorated.GetIngredients();
            Assert.Contains(ingredients, i => i.Name == "Regular Milk");
        }
    }
}