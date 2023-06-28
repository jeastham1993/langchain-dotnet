using LangChain.NET.Base;
using LangChain.NET.Cache;
using LangChain.NET.Schema;

namespace LangChain.NET.LLMS;

public abstract class BaseLlm : BaseLanguageModel
{
    private readonly BaseCache? _cache;
    
    protected BaseLlm(IBaseLlmParams parameters) : base(parameters)
    {
        _cache = parameters.Cache;
    }

    public override async Task<LlmResult> GeneratePrompt(BasePromptValue[] promptValues, List<string>? stop)
    {
        return await Generate(promptValues.Select(p => p.ToString()).ToArray(), stop);
    }

    public abstract Task<LlmResult> Generate(string[] prompts, List<string>? stop);

    public async Task<string?> Call(string prompt, List<string>? stop = null)
    {
        var generations = await Generate(new[] { prompt }, stop);

        return generations.Generations[0].Text;
    }
}