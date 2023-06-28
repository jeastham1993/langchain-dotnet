using LangChain.NET.Base;
using LangChain.NET.Callback;
using LangChain.NET.Prompts.Base;
using LangChain.NET.Schema;

namespace LangChain.NET.Chains.LLM;

public interface ILlmChainInput<T> : IChainInputs
{
    BasePromptTemplate<T> Prompt { get; }
    BaseLanguageModel Llm { get; }
    BaseOutputParser<T>? OutputParser { get; }
    string OutputKey { get; set; }
}

public class LlmChainInput<T> : ILlmChainInput<T>
{
    public BasePromptTemplate<T> Prompt { get; set; }
    public BaseLanguageModel Llm { get; set; }
    public BaseOutputParser<T> OutputParser { get; set; }
    public string OutputKey { get; set; }
    public bool? Verbose { get; set; }
    public CallbackManager CallbackManager { get; set; }
}