namespace LangChain.NET.Abstractions.Embeddings.Base;

/// <summary>
/// Interface for embedding models.
/// </summary>
/// <see cref="https://api.python.langchain.com/en/latest/embeddings/langchain.embeddings.base.Embeddings.html"/>
public interface IEmbeddings
{
    Task<float[,]> EmbedDocumentsAsync(string[] texts);
    Task<float[]> EmbedQueryAsync(string text);
}