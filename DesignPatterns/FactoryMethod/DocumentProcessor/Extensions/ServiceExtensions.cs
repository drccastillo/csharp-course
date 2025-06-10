using Microsoft.Extensions.DependencyInjection;
using DocumentProcessor.Services;
using DocumentProcessor.Cli;

namespace DocumentProcessor.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDocumentProcessorServices(this IServiceCollection services)
        {
            services.AddSingleton<DocumentProcessorFactory, PdfProcessorFactory>();
            services.AddSingleton<DocumentProcessorFactory, WordProcessorFactory>();
            services.AddSingleton<DocumentProcessorFactory, ExcelProcessorFactory>();
            services.AddSingleton<DocumentService>();
            services.AddSingleton<DocumentCli>();
            return services;
        }
    }
}