using LangChain.NET.Base;
using LangChain.NET.Callback;
using LangChain.NET.Prompts.Base;
using LangChain.NET.Schema;

namespace LangChain.NET.Chains.LLM;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class LlmChain<T> : BaseChain, ILlmChainInput<T>
{
    public BasePromptTemplate<T> Prompt { get; }
    public BaseLanguageModel Llm { get; }
    public string OutputKey { get; set; }
    public BaseOutputParser<T>? OutputParser { get; }
    public override string ChainType() => "llm_chain";

    public bool? Verbose { get; set; }
    public CallbackManager? CallbackManager { get; set; }

    public override string[] InputKeys => Prompt.InputVariables.ToArray();
    public override string[] OutputKeys => new[] { OutputKey };

    public LlmChain(LlmChainInput<T> fields)
    {
        Prompt = fields.Prompt;
        Llm = fields.Llm;
        OutputKey = fields.OutputKey;
        OutputParser = fields.OutputParser;

        if (OutputParser != null)
        {
            throw new Exception("Cannot set both OutputParser and Prompt.OutputParser");
        }
            
        OutputParser = Prompt.OutputParser;
    }

    protected async Task<object?> GetFinalOutput(
        List<Generation> generations, 
        BasePromptValue promptValue, 
        CallbackManagerForChainRun? runManager = null)
    {
        string? completion = generations[0].Text;
        object? finalCompletion;

        if (OutputParser != null)
        {
            finalCompletion = await OutputParser.ParseWithPrompt(completion, promptValue);
        }
        else
        {
            finalCompletion = completion;
        }

        return finalCompletion;
    }

    protected override async Task<ChainValues> Call(ChainValues values)
    {
        List<string>? stop = new List<string>();

        if (values.Value.TryGetValue("stop", out var value))
        {
            var stopList = value as List<string>;
                
            stop = stopList;
        }
        
        BasePromptValue promptValue = await Prompt.FormatPromptValue(new InputValues
        {
            Value = values.Value
        });
        var generationResult = await Llm.GeneratePrompt(new List<BasePromptValue> { promptValue }.ToArray(), stop);
        var generations = generationResult.Generations;
        
        return new ChainValues(await GetFinalOutput(generations.ToList(), promptValue));
    }
    
    public async Task<T> Predict(ChainValues values, BaseRunManager? callbackManager = null)
    {
        var output = await Call(values, callbackManager as CallbackManagerForChainRun);
        return (T)output.Value[OutputKey];
    }
}