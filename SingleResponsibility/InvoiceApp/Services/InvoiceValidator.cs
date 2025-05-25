using InvoiceApp.Interfaces;

namespace InvoiceApp.Services;

public class InvoiceValidator : IInvoiceValidator
{
    public void Validate(string[] args)
    {
        if (args == null || args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
        {
            throw new ArgumentException("Expecting JSON invoices!");
        }
    }
}