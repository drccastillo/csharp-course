using System;
using System.Collections.Generic;
using System.Linq;
using DocumentProcessor.Models;

namespace DocumentProcessor.Services;

public class DocumentService
{
    private readonly Dictionary<DocumentType, DocumentProcessorFactory> _factories;

    public DocumentService(IEnumerable<DocumentProcessorFactory> factories)
    {
        _factories = factories.ToDictionary(
            f => f.SupportedType,
            f => f);
    }

    public void ProcessDocument(DocumentType documentType, string content)
    {
        if (!_factories.TryGetValue(documentType, out var factory))
        {
            throw new NotSupportedException($"Document type '{documentType}' is not supported");
        }

        factory.ProcessDocument(content);
    }

    public IEnumerable<DocumentType> GetSupportedFormats()
    {
        return _factories.Keys;
    }
}