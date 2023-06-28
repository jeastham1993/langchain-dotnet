using LangChain.NET.LLMS;
using LangChain.NET.Schema;

namespace LangChain.NET.Base;

public interface IBaseCallbackHandler
{
    string Name { get; }
    
    public Task HandleLlmStartAsync(
        BaseLlm llm,
        string[] prompts,
        string runId,
        string? parentRunId = null,
        Dictionary<string, object>? extraParams = null);

    public Task HandleLlmNewTokenAsync(
        string token,
        string runId,
        string? parentRunId = null);

    public Task HandleLlmErrorAsync(
        Exception err,
        string runId,
        string? parentRunId = null);

    public Task HandleLlmEndAsync(
        LlmResult output,
        string runId,
        string? parentRunId = null);

    public Task HandleChatModelStartAsync(
        Dictionary<string, object> llm,
        List<List<object>> messages,
        string runId,
        string? parentRunId = null,
        Dictionary<string, object>? extraParams = null);

    public Task HandleChainStartAsync(
        Dictionary<string, object> chain,
        Dictionary<string, object> inputs,
        string runId,
        string? parentRunId = null);

    public Task HandleChainErrorAsync(
        Exception err,
        string runId,
        string? parentRunId = null);

    public Task HandleChainEndAsync(
        Dictionary<string, object> outputs,
        string runId,
        string? parentRunId = null);

    public Task HandleToolStartAsync(
        Dictionary<string, object> tool,
        string input,
        string runId,
        string? parentRunId = null);

    public Task HandleToolErrorAsync(
        Exception err,
        string runId,
        string? parentRunId = null);

    public Task HandleToolEndAsync(
        string output,
        string runId,
        string? parentRunId = null);

    public Task HandleTextAsync(
        string text,
        string runId,
        string? parentRunId = null);

    public Task HandleAgentActionAsync(
        Dictionary<string, object> action,
        string runId,
        string? parentRunId = null);

    public Task HandleAgentEndAsync(
        Dictionary<string, object> action,
        string runId,
        string? parentRunId = null);
}

public interface IBaseCallbackHandlerInput
{
    bool IgnoreLlm { get; set; }
    bool IgnoreChain { get; set; }
    bool IgnoreAgent { get; set; }
}

public abstract class BaseCallbackHandler : IBaseCallbackHandler
{
    public string Name { get; protected set; }

    public abstract Task HandleLlmStartAsync(BaseLlm llm, string[] prompts, string runId, string? parentRunId = null,
        Dictionary<string, object>? extraParams = null);

    public abstract Task HandleLlmNewTokenAsync(string token, string runId, string? parentRunId = null);
    public abstract Task HandleLlmErrorAsync(Exception err, string runId, string? parentRunId = null);
    public abstract Task HandleLlmEndAsync(LlmResult output, string runId, string? parentRunId = null);

    public abstract Task HandleChatModelStartAsync(Dictionary<string, object> llm, List<List<object>> messages, string runId, string? parentRunId = null,
        Dictionary<string, object>? extraParams = null);

    public abstract Task HandleChainStartAsync(Dictionary<string, object> chain, Dictionary<string, object> inputs, string runId, string? parentRunId = null);
    public abstract Task HandleChainErrorAsync(Exception err, string runId, string? parentRunId = null);
    public abstract Task HandleChainEndAsync(Dictionary<string, object> outputs, string runId, string? parentRunId = null);
    public abstract Task HandleToolStartAsync(Dictionary<string, object> tool, string input, string runId, string? parentRunId = null);
    public abstract Task HandleToolErrorAsync(Exception err, string runId, string? parentRunId = null);
    public abstract Task HandleToolEndAsync(string output, string runId, string? parentRunId = null);
    public abstract Task HandleTextAsync(string text, string runId, string? parentRunId = null);
    public abstract Task HandleAgentActionAsync(Dictionary<string, object> action, string runId, string? parentRunId = null);
    public abstract Task HandleAgentEndAsync(Dictionary<string, object> action, string runId, string? parentRunId = null);

    public bool IgnoreLlm { get; set; }
    public bool IgnoreChain { get; set; }
    public bool IgnoreAgent { get; set; }

    protected BaseCallbackHandler()
    {
        Name = Guid.NewGuid().ToString();
    }

    protected BaseCallbackHandler(IBaseCallbackHandlerInput input) : this()
    {
        IgnoreLlm = input.IgnoreLlm;
        IgnoreChain = input.IgnoreChain;
        IgnoreAgent = input.IgnoreAgent;
    }

    public abstract IBaseCallbackHandler Copy();
}

public abstract class Handler : BaseCallbackHandler
{
    public override IBaseCallbackHandler Copy()
    {
        throw new NotImplementedException();
    }
}