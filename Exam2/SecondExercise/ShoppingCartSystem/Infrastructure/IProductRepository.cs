namespace ShoppingCartSystem;

public interface IProductRepository
{
  IProduct GetProduct(string name);
}