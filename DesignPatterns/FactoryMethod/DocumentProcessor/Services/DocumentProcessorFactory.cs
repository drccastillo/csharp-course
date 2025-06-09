using System;
using DocumentProcessor.Interfaces;
using DocumentProcessor.Models;

namespace DocumentProcessor.Services;

public abstract class DocumentProcessorFactory
{
    public abstract DocumentType SupportedType { get; }

    public abstract IDocumentProcessor CreateProcessor();

    public void ProcessDocument(string content)
    {
        var processor = CreateProcessor();
        processor.ProcessDocument(content);

        Console.WriteLine($"Document processed using {SupportedType} processor");
        Console.WriteLine("Processing completed successfully.\n");
    }
}