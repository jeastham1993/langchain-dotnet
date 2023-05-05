using System.Text.Json.Serialization;

namespace LangChain.NET.LLMS.HuggingFace;

public class HuggingFaceInferenceResponse{
    [JsonPropertyName("generated_text")]
    public string GeneratedText {get;set;}
}
