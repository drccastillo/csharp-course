using InvoiceApp.Cli;
using InvoiceApp.Interfaces;
using InvoiceApp.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);
var services = builder.Services;

services.AddSingleton<IInvoiceParser, InvoiceParser>();
services.AddSingleton<IInvoiceCalculator, InvoiceCalculator>();
services.AddSingleton<IReportFormatter, AsciiReportFormatter>();
services.AddSingleton<IInvoiceValidator, InvoiceValidator>();
services.AddSingleton<InvoiceCli>();

using var host = builder.Build();

var sampleJson = "[{\"Id\":1,\"Customer\":\"John Doe\",\"Amount\":100.50,\"Date\":\"2023-10-01\"},{\"Id\":2,\"Customer\":\"Jane Smith\",\"Amount\":200.75,\"Date\":\"2023-10-02\"}]";

if (args.Length == 0)
{
  args = new[] { sampleJson };
}

host.Services.GetRequiredService<InvoiceCli>().Run(args);