namespace ShoppingCartSystem;

public interface ICartProcessor
{
  void Process(IEnumerable<ProductQuantity> items);
}
