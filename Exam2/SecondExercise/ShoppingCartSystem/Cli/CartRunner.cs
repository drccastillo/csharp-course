namespace ShoppingCartSystem.Cli;

public class CartRunner
{
  private readonly ShoppingCart cart;
  private readonly IProductRepository repo;

  public CartRunner(ShoppingCart cart, IProductRepository repo)
  {
    this.cart = cart;
    this.repo = repo;
  }

  public void Run(string[] args)
  {
    foreach (var arg in args)
    {
      var parts = arg.Split(':');
      if (parts.Length == 2 && int.TryParse(parts[1], out var qty))
      {
        var product = repo.GetProduct(parts[0]);
        cart.AddItem(product, qty);
      }
      else
      {
        var product = repo.GetProduct(arg);
        cart.AddItem(product);
      }
    }

    cart.DisplayCart();
    cart.Checkout();
  }
}