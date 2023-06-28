using System.Text.Json.Serialization;

namespace LangChain.NET.LLMS.OpenAi;

internal class OpenAiChatMessage
{
    [JsonPropertyName("role")]
    public string Role { get; set; }
    
    [JsonPropertyName("content")]
    public string Content { get; set; }
}