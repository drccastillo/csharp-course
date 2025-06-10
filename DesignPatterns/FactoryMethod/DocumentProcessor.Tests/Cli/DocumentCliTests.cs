using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using DocumentProcessor.Cli;
using DocumentProcessor.Extensions;
using DocumentProcessor.Models;
using Xunit;

namespace DocumentProcessor.Tests.Cli
{
    public class DocumentCliTests
    {
        private DocumentCli CreateCli(TextWriter writer)
        {
            var services = new ServiceCollection();
            services.AddDocumentProcessorServices();
            var sp = services.BuildServiceProvider();
            Console.SetOut(writer);
            return sp.GetRequiredService<DocumentCli>();
        }

        [Fact]
        public void Run_NoArgs_PrintsUsageAndSupportedFormats()
        {
            var output = new StringWriter();
            var cli = CreateCli(output);

            cli.Run(Array.Empty<string>());

            var result = output.ToString();
            Assert.Contains("Usage:", result);
            Assert.Contains("Supported types:", result);
        }

        [Fact]
        public void Run_InvalidType_PrintsInvalidTypeError()
        {
            var output = new StringWriter();
            var cli = CreateCli(output);

            cli.Run(new[] { "InvalidType", "content" });

            var result = output.ToString();
            Assert.Contains("Invalid document type 'InvalidType'", result);
            Assert.Contains("Supported types:", result);
        }

        [Fact]
        public void Run_ValidType_ProcessesDocument()
        {
            var output = new StringWriter();
            var cli = CreateCli(output);

            const string content = "test-content";
            cli.Run(new[] { "Pdf", content });

            var result = output.ToString();
            Assert.Contains("Processing", result);
            Assert.Contains(content, result);
            Assert.Contains("Document processed using Pdf processor", result);
        }
    }
}