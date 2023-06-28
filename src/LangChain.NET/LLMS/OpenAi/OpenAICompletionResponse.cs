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

internal class OpenAiCompletionResponse
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
    public Choices[] Choices { get; set; }
    
    [JsonPropertyName("usage")]
    public Usage Usage { get; set; }
}

public class Choices
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
    
    [JsonPropertyName("index")]
    public int Index { get; set; }
    
    [JsonPropertyName("logprobs")]
    public object Logprobs { get; set; }
    
    [JsonPropertyName("finishReason")]
    public string FinishReason { get; set; }
}

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

public class ChatMessage
{
    [JsonPropertyName("content")]
    public string Content { get; set; }
    
    [JsonPropertyName("role")]
    public string Role { get; set; }
}

public class Usage
{
    [JsonPropertyName("promptTokens")]
    public int PromptTokens { get; set; }
    
    [JsonPropertyName("completionTokens")]
    public int CompletionTokens { get; set; }
    
    [JsonPropertyName("totalTokens")]
    public int TotalTokens { get; set; }
}





