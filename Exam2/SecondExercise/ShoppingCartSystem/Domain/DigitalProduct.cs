namespace ShoppingCartSystem;

public class DigitalProduct : IProduct, IDownloadable
{
  public string Name { get; set; }
  public decimal Price { get; set; }
  public string DownloadUrl { get; set; }

  public void Download() => Console.WriteLine($"Downloading from: {DownloadUrl}");
}