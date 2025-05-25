namespace Problem3.Application.Services;

public interface IBrowserService
{
    void Navigate(string url);
    void Back();
    void Forward();
    string? Current();
}