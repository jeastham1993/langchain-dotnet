using LangChain.NET.Cache;

namespace LangChain.NET.LLMS.OpenAi;

public class OpenAiOptions : IBaseLlmParams
{
    public string ApiKey { get; set; }
    
    public OpenAiConfiguration Configuration { get; set; }
    
    public bool? Verbose { get; set; }
    
    public decimal? Concurrency { get; set; }
    public BaseCache? Cache { get; set; }
}