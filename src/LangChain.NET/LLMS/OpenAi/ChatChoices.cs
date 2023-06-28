using System.Text.Json.Serialization;

namespace LangChain.NET.LLMS.OpenAi;

public class ChatChoices
{
    [JsonPropertyName("message")]
    public ChatMessage Message { get; set; }
    
    [JsonPropertyName("index")]
    public int Index { get; set; }
    
    [JsonPropertyName("logprobs")]
    public object Logprobs { get; set; }
    
    [JsonPropertyName("finishReason")]
    public string FinishReason { get; set; }
}