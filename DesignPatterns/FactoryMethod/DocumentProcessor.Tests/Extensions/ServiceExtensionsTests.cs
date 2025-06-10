using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using DocumentProcessor.Extensions;
using DocumentProcessor.Models;
using DocumentProcessor.Services;
using DocumentProcessor.Cli;
using Xunit;

namespace DocumentProcessor.Tests.Extensions
{
    public class ServiceExtensionsTests
    {
        [Fact]
        public void AddDocumentProcessorServices_RegistersServicesAndFactories()
        {
            var services = new ServiceCollection();
            services.AddDocumentProcessorServices();
            var sp = services.BuildServiceProvider();

            var factories = sp.GetServices<DocumentProcessorFactory>().ToList();
            Assert.Equal(3, factories.Count);
            var supportedTypes = factories.Select(f => f.SupportedType);
            Assert.Contains(DocumentType.Pdf, supportedTypes);
            Assert.Contains(DocumentType.Word, supportedTypes);
            Assert.Contains(DocumentType.Excel, supportedTypes);

            Assert.NotNull(sp.GetService<DocumentService>());
            Assert.NotNull(sp.GetService<DocumentCli>());
        }
    }
}