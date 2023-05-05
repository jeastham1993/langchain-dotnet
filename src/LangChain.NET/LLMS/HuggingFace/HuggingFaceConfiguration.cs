using LangChain.NET.Cache;

namespace LangChain.NET.LLMS.HuggingFace;

public class HuggingFaceConfiguration : BaseLLMParams
{
    public HuggingFaceConfiguration()
    {
        this.Temperature = 0.7M;
        this.ModelName = "gpt2";
    }
    
    /// <summary>
    ///  Sampling temperature to use
    /// </summary>
    public decimal Temperature { get; set; }
    
    public bool? Verbose { get; set; }
    public string ApiKey { get; set; }
    
    public decimal? Concurrency { get; set; }
    public BaseCache? Cache { get; set; }
    
    public string ModelName { get; set; }
}