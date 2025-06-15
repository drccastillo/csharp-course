using CoffeeShop.Interfaces;
using CoffeeShop.Models.Components;
using CoffeeShop.Services.Builder;
using CoffeeShop.Services.Decorator;
using CoffeeShop.Services.Facade;

// Demonstration of Decorator and Facade patterns
var facade = new CoffeeShopServiceFacade();
facade.ShowMenu();

var customCoffee = facade.CreateCustomCoffee("Americano");
var order = new CoffeeOrderBuilder(customCoffee)
    .WithSize("Large")
    .WithMilk("Soy")
    .WithSugar(2, "Brown")
    .Build();

facade.PrintReceipt(order);
