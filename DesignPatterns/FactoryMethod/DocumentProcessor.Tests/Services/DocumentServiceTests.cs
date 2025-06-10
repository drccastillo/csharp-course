using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using DocumentProcessor.Extensions;
using DocumentProcessor.Models;
using DocumentProcessor.Services;
using Xunit;

namespace DocumentProcessor.Tests.Services
{
    public class DocumentServiceTests
    {
        private readonly DocumentService _service;

        public DocumentServiceTests()
        {
            var services = new ServiceCollection();
            services.AddDocumentProcessorServices();
            _service = services.BuildServiceProvider().GetRequiredService<DocumentService>();
        }

        [Fact]
        public void GetSupportedFormats_ReturnsAllDocumentTypes()
        {
            var formats = _service.GetSupportedFormats();
            Assert.Contains(DocumentType.Pdf, formats);
            Assert.Contains(DocumentType.Word, formats);
            Assert.Contains(DocumentType.Excel, formats);
        }

        [Fact]
        public void ProcessDocument_UnsupportedType_ThrowsNotSupportedException()
        {
            Assert.Throws<NotSupportedException>(() => _service.ProcessDocument((DocumentType)int.MaxValue, "content"));
        }

        [Theory]
        [InlineData(DocumentType.Pdf, "pdf-content")]
        [InlineData(DocumentType.Word, "word-content")]
        [InlineData(DocumentType.Excel, "excel-content")]
        public void ProcessDocument_ValidType_WritesExpectedOutput(DocumentType type, string content)
        {
            var output = new StringWriter();
            Console.SetOut(output);

            _service.ProcessDocument(type, content);
            var result = output.ToString();

            Assert.Contains("Processing", result);
            Assert.Contains(content, result);
            Assert.Contains($"Document processed using {type} processor", result);
        }
    }
}