using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DocumentProcessor.Cli;
using DocumentProcessor.Extensions;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddDocumentProcessorServices();

using var host = builder.Build();
var cli = host.Services.GetRequiredService<DocumentCli>();
cli.Run(args);