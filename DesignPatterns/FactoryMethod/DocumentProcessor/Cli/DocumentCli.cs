using System;
using System.Linq;
using DocumentProcessor.Models;
using DocumentProcessor.Services;

namespace DocumentProcessor.Cli
{
    public class DocumentCli
    {
        private readonly DocumentService _service;

        public DocumentCli(DocumentService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Run(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: <program> <documentType> <content>");
                Console.WriteLine($"Supported types: {string.Join(", ", _service.GetSupportedFormats())}");
                return;
            }

            var typeArg = args[0];
            if (!Enum.TryParse<DocumentType>(typeArg, true, out var type))
            {
                Console.WriteLine($"Invalid document type '{typeArg}'. Supported types: {string.Join(", ", _service.GetSupportedFormats())}");
                return;
            }

            var content = string.Join(" ", args.Skip(1));
            try
            {
                _service.ProcessDocument(type, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing document: {ex.Message}");
            }
        }
    }
}