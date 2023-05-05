using LangChain.NET.Base;
using LangChain.NET.Cache;
using LangChain.NET.Schema;

namespace LangChain.NET.LLMS;

public interface BaseLLMParams : BaseLanguageModelParams
{
    internal decimal? Concurrency { get; set; }
    
    internal BaseCache? Cache { get; set; }
}

public interface BaseLLMCallOptions : BaseLanguageModelCallOptions { }

public abstract class BaseLLM : BaseLanguageModel
{
    private readonly BaseCache? _cache;
    
    protected BaseLLM(BaseLLMParams parameters) : base(parameters)
    {
        this._cache = parameters.Cache;
    }

    public override async Task<LLMResult> GeneratePrompt(BasePromptValue[] promptValues, string[]? stop)
    {
        return await this.Generate(promptValues.Select(p => p.ToString()).ToArray(), stop);
    }

    public abstract Task<LLMResult> Generate(string[] prompts, string[]? stop);

    public async Task<string> Call(string prompt, string[]? stop = null)
    {
        var generations = await this.Generate(new[] { prompt }, stop);

        return generations.Generations[0].Text;
    }
}