using DocumentProcessor.Interfaces;
using DocumentProcessor.Models;
using DocumentProcessor.Processors;

namespace DocumentProcessor.Services;

public class WordProcessorFactory : DocumentProcessorFactory
{
    public override DocumentType SupportedType => DocumentType.Word;

    public override IDocumentProcessor CreateProcessor()
    {
        // We can have more logic to create the instance
        return new WordDocumentProcessor();
    }
}