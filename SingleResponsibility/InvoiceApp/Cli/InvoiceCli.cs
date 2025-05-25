using InvoiceApp.Interfaces;

namespace InvoiceApp.Cli;

public class InvoiceCli(
  IInvoiceParser invoiceParser,
  IInvoiceCalculator invoiceCalculator,
  IReportFormatter reportFormatter,
  IInvoiceValidator invoiceValidator)
{
  private readonly IInvoiceParser _invoiceParser = invoiceParser;
  private readonly IInvoiceCalculator _invoiceCalculator = invoiceCalculator;
  private readonly IReportFormatter _reportFormatter = reportFormatter;
  private readonly IInvoiceValidator _invoiceValidator = invoiceValidator;

  public void Run(string[] args)
  {
    _invoiceValidator.Validate(args);

    var json = args[0];
    var invoices = _invoiceParser.Parse(json);
    var (total, average) = _invoiceCalculator.Calculate(invoices);
    var report = _reportFormatter.Format(invoices, total, average);

    Console.WriteLine(report);
  }
}