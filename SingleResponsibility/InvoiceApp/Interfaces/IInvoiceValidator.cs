namespace InvoiceApp.Interfaces;

public interface IInvoiceValidator
{
    /// <summary>
    /// Validates the command-line arguments for the CLI application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    void Validate(string[] args);
}