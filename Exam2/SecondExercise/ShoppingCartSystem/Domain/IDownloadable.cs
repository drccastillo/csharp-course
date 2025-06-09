namespace ShoppingCartSystem;

public interface IDownloadable
{
  string DownloadUrl { get; }
  void Download();
}