using LangChain.NET.Base;
using LangChain.NET.Callback;
using LangChain.NET.Prompts.Base;
using LangChain.NET.Schema;

namespace LangChain.NET.Chains.LLM;

public interface ILlmChainInput : IChainInputs
{
    BasePromptTemplate Prompt { get; }
    BaseLanguageModel Llm { get; }
    string OutputKey { get; set; }
}

public class LlmChainInput<T> : ILlmChainInput
{
    public BasePromptTemplate Prompt { get; set; }
    public BaseLanguageModel Llm { get; set; }
    public BaseOutputParser<T> OutputParser { get; set; }
    public string OutputKey { get; set; }
    public bool? Verbose { get; set; }
    public CallbackManager CallbackManager { get; set; }
}