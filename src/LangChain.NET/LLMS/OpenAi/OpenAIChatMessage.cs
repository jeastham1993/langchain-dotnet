using System.Text.Json.Serialization;

namespace LangChain.NET.LLMS.OpenAi;

internal class OpenAIChatMessage
{
    [JsonPropertyName("role")]
    public string Role { get; set; }
    
    [JsonPropertyName("content")]
    public string Content { get; set; }
}