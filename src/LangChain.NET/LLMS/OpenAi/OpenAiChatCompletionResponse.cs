using System.Text.Json.Serialization;

namespace LangChain.NET.LLMS.OpenAi;

internal class OpenAiChatCompletionResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("object")]
    public string Object { get; set; }
    
    [JsonPropertyName("created")]
    public int Created { get; set; }
    
    [JsonPropertyName("model")]
    public string Model { get; set; }
    
    [JsonPropertyName("choices")]
    public ChatChoices[] Choices { get; set; }
    
    [JsonPropertyName("usage")]
    public Usage Usage { get; set; }
}