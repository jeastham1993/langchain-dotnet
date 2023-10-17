using LangChain.NET.Base;
using LangChain.NET.Callback;
using LangChain.NET.Memory;
using LangChain.NET.Prompts.Base;

namespace LangChain.NET.Chains.LLM;

public class LlmChainInput: ILlmChainInput
{
    public LlmChainInput(BaseLanguageModel llm, BasePromptTemplate prompt,BaseMemory memory)
    {
        this.Llm = llm;
        this.Prompt = prompt;
        this.Memory = memory;
    }
    
    public BasePromptTemplate Prompt { get; set; }
    public BaseLanguageModel Llm { get; set; }
    public string OutputKey { get; set; }
    public bool? Verbose { get; set; }
    public CallbackManager CallbackManager { get; set; }
    public BaseMemory Memory { get; set; }
}