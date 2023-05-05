using LangChain.NET.Schema;
using Microsoft.DeepDev;

namespace LangChain.NET.Base;

public interface BaseLanguageModelParams : BaseLangChainParams
{
    public string ApiKey { get; set; }
}

public interface BaseLanguageModelCallOptions
{
}

public abstract class BaseLanguageModel : BaseLangChain
{
    public BaseLanguageModel(BaseLanguageModelParams parameters) : base(parameters)
    {
    }

    public abstract string ModelType { get; set; }

    public abstract string LLMType { get; set; }

    public abstract TikTokenizer Tokenizer { get; set; }

    public abstract Task<LLMResult> GeneratePrompt(BasePromptValue[] promptValues, string[]? stop);
}