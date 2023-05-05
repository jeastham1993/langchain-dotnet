using System.Text.Json.Serialization;

namespace LangChain.NET.LLMS.OpenAi;

internal class OpenAICompletionResponse
{
    public string id { get; set; }
    public string Object { get; set; }
    public int created { get; set; }
    public string model { get; set; }
    public Choices[] choices { get; set; }
    public Usage usage { get; set; }
}

public class Choices
{
    public string text { get; set; }
    public int index { get; set; }
    public object logprobs { get; set; }
    public string finish_reason { get; set; }
}

public class Usage
{
    public int prompt_tokens { get; set; }
    public int completion_tokens { get; set; }
    public int total_tokens { get; set; }
}





