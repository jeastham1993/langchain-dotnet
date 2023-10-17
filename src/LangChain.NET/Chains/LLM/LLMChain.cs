using Azure.AI.OpenAI;
using LangChain.NET.Base;
using LangChain.NET.Callback;
using LangChain.NET.Chat;
using LangChain.NET.Memory;
using LangChain.NET.Prompts;
using LangChain.NET.Prompts.Base;
using LangChain.NET.Schema;
using ChatMessage = LangChain.NET.Chat.ChatMessage;

namespace LangChain.NET.Chains.LLM;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class LlmChain : BaseChain, ILlmChainInput
{
    public BasePromptTemplate Prompt { get; }
    public BaseLanguageModel Llm { get; }
    public BaseMemory Memory { get; }
    public string OutputKey { get; set; }
    public override string ChainType() => "llm_chain";

    public bool? Verbose { get; set; }
    public CallbackManager? CallbackManager { get; set; }

    public override string[] InputKeys => Prompt.InputVariables.ToArray();
    public override string[] OutputKeys => new[] { OutputKey };

    public LlmChain(LlmChainInput fields)
    {
        Prompt = fields.Prompt;
        Llm = fields.Llm;
        OutputKey = fields.OutputKey;
        Memory = fields.Memory;
    }

    protected async Task<object?> GetFinalOutput(
        List<Generation> generations,
        BasePromptValue promptValue,
        CallbackManagerForChainRun? runManager = null)
    {
        return generations[0].Text;
    }

    /// <summary>
    /// Execute the chain.
    /// </summary>
    /// <param name="values">The values to use when executing the chain.</param>
    /// <returns>The resulting output <see cref="ChainValues"/>.</returns>
    public override async Task<ChainValues> Call(ChainValues values)
    {
        List<string>? stop = new List<string>();
        var dict = Memory.LoadMemoryVariables(null);
        if (values.Value.TryGetValue("stop", out var value))
        {
            var stopList = value as List<string>;

            stop = stopList;
        }

        //add history in account
        BasePromptValue promptValue = await Prompt.FormatPromptValue(new InputValues(values.Value));
        StringPromptValue historyIncluded = new StringPromptValue();
        historyIncluded.Value = GetHistorySummary() + promptValue;
        var generationResult = await Llm.GeneratePrompt(new List<BasePromptValue> { historyIncluded }.ToArray(), stop);
        var generations = generationResult.Generations;

        return new ChainValues(await GetFinalOutput(generations.ToList(), promptValue));
    }

    private string GetHistorySummary()
    {
        string history = "These are our previous conversations:\n";
        var messages = Memory.LoadMemoryVariables(null);
        if (messages.Value is Dictionary<string, object> messageDict &&
            messageDict["history"] is ChatMessageHistory msg)
        {
            foreach (var chatMessage in msg.Messages)
                history += chatMessage.Text + "\n";
        }

        return history;
    }

    public async Task<object> Predict(ChainValues values)
    {
        var output = await Call(values);
        return output.Value[OutputKey];
    }
}