using System.Text.Json.Serialization;

namespace LangChain.NET.LLMS.OpenAi;

public class Usage
{
    [JsonPropertyName("promptTokens")]
    public int PromptTokens { get; set; }
    
    [JsonPropertyName("completionTokens")]
    public int CompletionTokens { get; set; }
    
    [JsonPropertyName("totalTokens")]
    public int TotalTokens { get; set; }
}