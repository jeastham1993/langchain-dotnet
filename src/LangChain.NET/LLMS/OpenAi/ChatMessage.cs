using System.Text.Json.Serialization;

namespace LangChain.NET.LLMS.OpenAi;

public class ChatMessage
{
    [JsonPropertyName("content")]
    public string Content { get; set; }
    
    [JsonPropertyName("role")]
    public string Role { get; set; }
}