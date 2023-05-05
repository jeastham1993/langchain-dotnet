using LangChain.NET.Cache;

namespace LangChain.NET.LLMS.HuggingFace;

public class HuggingFaceConfiguration : BaseLLMParams
{
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