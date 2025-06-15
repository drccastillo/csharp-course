using CoffeeShop.Models;
using Xunit;

namespace CoffeeShop.Tests.Utils
{
    public class IngredientTests
    {
        [Fact]
        public void Ingredient_Record_HoldsValuesCorrectly()
        {
            var ingredient = new Ingredient("Test", 1.23m, 45);
            Assert.Equal("Test", ingredient.Name);
            Assert.Equal(1.23m, ingredient.Cost);
            Assert.Equal(45, ingredient.Calories);
        }

        [Fact]
        public void Ingredients_EqualityBasedOnValues()
        {
            var ing1 = new Ingredient("Sugar", 0.30m, 16);
            var ing2 = new Ingredient("Sugar", 0.30m, 16);
            Assert.Equal(ing1, ing2);
        }
    }
}