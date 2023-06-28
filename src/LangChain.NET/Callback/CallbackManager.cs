using LangChain.NET.Base;
using LangChain.NET.LLMS;
using LangChain.NET.Schema;

namespace LangChain.NET.Callback;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICallbackManagerOptions
{
    bool Verbose { get; set; }
    bool Tracing { get; set; }
}

public delegate Task<object> CallbackManagerMethod(params object[] args);

public class BaseRunManager
{
    public string RunId { get; }
    protected List<BaseCallbackHandler> Handlers { get; }
    protected List<BaseCallbackHandler> InheritableHandlers { get; }
    protected string? ParentRunId { get; }

    public BaseRunManager(string runId, List<BaseCallbackHandler> handlers, List<BaseCallbackHandler> inheritableHandlers, string? parentRunId = null)
    {
        RunId = runId;
        Handlers = handlers;
        InheritableHandlers = inheritableHandlers;
        ParentRunId = parentRunId;
    }

    public async Task HandleText(string text)
    {
        foreach (var handler in Handlers)
        {
            try
            {
                await handler.HandleTextAsync(text, RunId, ParentRunId);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in handler {handler.GetType().Name}, HandleText: {ex}");
            }
        }
    }
}

public class CallbackManagerForLlmRun : BaseRunManager
{
    public CallbackManagerForLlmRun(string runId, List<BaseCallbackHandler> handlers, List<BaseCallbackHandler> inheritableHandlers, string? parentRunId = null)
        : base(runId, handlers, inheritableHandlers, parentRunId)
    {
    }

    public Task HandleToolEndAsync(string output, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleTextAsync(string text, string runId, string parentRunId)
    {
        throw new NotImplementedException();
    }

    public Task HandleAgentActionAsync(Dictionary<string, object> action, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleAgentEndAsync(Dictionary<string, object> action, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleLlmStartAsync(Dictionary<string, object> llm, string[] prompts, string runId, string? parentRunId = null,
        Dictionary<string, object>? extraParams = null)
    {
        throw new NotImplementedException();
    }

    public async Task HandleLlmNewTokenAsync(string token, string runId, string parentRunId)
    {
        foreach (var handler in Handlers)
        {
            if (!handler.IgnoreLlm)
            {
                try
                {
                    await handler.HandleLlmNewTokenAsync(token, RunId, ParentRunId);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error in handler {handler.GetType().Name}, HandleLLMNewToken: {ex}");
                }
            }
        }
    }

    public async Task HandleLlmErrorAsync(Exception error, string runId, string parentRunId)
    {
        foreach (var handler in Handlers)
        {
            if (!handler.IgnoreLlm)
            {
                try
                {
                    await handler.HandleLlmErrorAsync(error, RunId, ParentRunId);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error in handler {handler.GetType().Name}, HandleLLMError: {ex}");
                }
            }
        }
    }

    public async Task HandleLlmEndAsync(LlmResult output, string runId, string parentRunId)
    {
        foreach (var handler in Handlers)
        {
            if (!handler.IgnoreLlm)
            {
                try
                {
                    await handler.HandleLlmEndAsync(output, RunId, ParentRunId);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error in handler {handler.GetType().Name}, HandleLLMEnd: {ex}");
                }
            }
        }
    }

    public Task HandleChatModelStartAsync(Dictionary<string, object> llm, List<List<object>> messages, string runId, string? parentRunId = null,
        Dictionary<string, object>? extraParams = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleChainStartAsync(Dictionary<string, object> chain, Dictionary<string, object> inputs, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleChainErrorAsync(Exception err, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleChainEndAsync(Dictionary<string, object> outputs, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleToolStartAsync(Dictionary<string, object> tool, string input, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleToolErrorAsync(Exception err, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }
}

public class CallbackManagerForChainRun : BaseRunManager
{
    public CallbackManagerForChainRun(string runId, List<BaseCallbackHandler> handlers, List<BaseCallbackHandler> inheritableHandlers, string? parentRunId = null)
        : base(runId, handlers, inheritableHandlers, parentRunId)
    {
    }

    public CallbackManager GetChild()
    {
        var manager = new CallbackManager(RunId);
        manager.SetHandlers(InheritableHandlers);
        return manager;
    }

    public async Task HandleChainEndAsync(ChainValues output)
    {
        foreach (var handler in Handlers)
        {
            if (!handler.IgnoreChain)
            {
                try
                {
                    await handler.HandleChainEndAsync(output.Value, RunId, ParentRunId);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error in handler {handler.GetType().Name}, HandleChainEnd: {ex}");
                }
            }
        }
    }

    public Task HandleLlmStartAsync(Dictionary<string, object> llm, string[] prompts, string runId, string? parentRunId = null,
        Dictionary<string, object>? extraParams = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleLlmNewTokenAsync(string token, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleLlmErrorAsync(Exception err, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleLlmEndAsync(LlmResult output, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleChatModelStartAsync(Dictionary<string, object> llm, List<List<object>> messages, string runId, string? parentRunId = null,
        Dictionary<string, object>? extraParams = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleChainStartAsync(Dictionary<string, object> chain, Dictionary<string, object> inputs, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public async Task HandleChainErrorAsync(Exception error, string runId, string? parentRunId = null)
    {
        foreach (var handler in Handlers)
        {
            if (!handler.IgnoreLlm)
            {
                try
                {
                    await handler.HandleChainErrorAsync(error, RunId, ParentRunId);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error in handler {handler.GetType().Name}, HandleChainError: {ex}");
                }
            }
        }
    }

    public Task HandleChainEndAsync(Dictionary<string, object> outputs, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleToolStartAsync(Dictionary<string, object> tool, string input, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleToolErrorAsync(Exception err, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleToolEndAsync(string output, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleTextAsync(string text, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleAgentActionAsync(Dictionary<string, object> action, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleAgentEndAsync(Dictionary<string, object> action, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }
}

public class CallbackManagerForToolRun : BaseRunManager
{
    public CallbackManagerForToolRun(string runId, List<BaseCallbackHandler> handlers, List<BaseCallbackHandler> inheritableHandlers, string? parentRunId = null)
        : base(runId, handlers, inheritableHandlers, parentRunId)
    {
    }

    public CallbackManager GetChild()
    {
        var manager = new CallbackManager(RunId);
        manager.SetHandlers(InheritableHandlers);
        return manager;
    }

    public Task HandleLlmStartAsync(Dictionary<string, object> llm, string[] prompts, string runId, string? parentRunId = null,
        Dictionary<string, object>? extraParams = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleLlmNewTokenAsync(string token, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleLlmErrorAsync(Exception err, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleLlmEndAsync(LlmResult output, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleChatModelStartAsync(Dictionary<string, object> llm, List<List<object>> messages, string runId, string? parentRunId = null,
        Dictionary<string, object>? extraParams = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleChainStartAsync(Dictionary<string, object> chain, Dictionary<string, object> inputs, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleChainErrorAsync(Exception err, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleChainEndAsync(Dictionary<string, object> outputs, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleToolStartAsync(Dictionary<string, object> tool, string input, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleToolErrorAsync(Exception err, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleToolEndAsync(string output, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleTextAsync(string text, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleAgentActionAsync(Dictionary<string, object> action, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleAgentEndAsync(Dictionary<string, object> action, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }
}


public class CallbackManager
{
    public List<BaseCallbackHandler> Handlers { get; private set; }
    public List<BaseCallbackHandler> InheritableHandlers { get; private set; }
    public string Name { get; } = "callback_manager";
    private readonly string? _parentRunId;

    public CallbackManager(string? parentRunId = null)
    {
        Handlers = new List<BaseCallbackHandler>();
        InheritableHandlers = new List<BaseCallbackHandler>();
        _parentRunId = parentRunId;
    }

    public async Task<CallbackManagerForLlmRun> HandleLlmStart(
        BaseLlm llm,
        List<string> prompts,
        string? runId = null,
        string? parentRunId = null,
        Dictionary<string, object>? extraParams = null)
    {
        foreach (var handler in Handlers)
        {
            if (!handler.IgnoreLlm)
            {
                try
                {
                    await handler.HandleLlmStartAsync(llm, prompts.ToArray(), runId ?? Guid.NewGuid().ToString(), _parentRunId, extraParams);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error in handler {handler.GetType().Name}, HandleLLMStart: {ex}");
                }
            }
        }

        return new CallbackManagerForLlmRun(runId, Handlers, InheritableHandlers, _parentRunId);
    }

    public async Task<CallbackManagerForLlmRun> HandleChatModelStart(
        BaseLlm llm,
        List<List<BaseChatMessage>> messages,
        string? runId = null,
        string? parentRunId = null,
        Dictionary<string, object>? extraParams = null)
    {
        List<string> messageStrings = null;
        foreach (var handler in Handlers)
        {
            if (!handler.IgnoreLlm)
            {
                /*try
                {
                    if (handler is IHandleChatModelStart handleChatModelStartHandler)
                    {
                        await handleChatModelStartHandler.HandleChatModelStart(llm, messages, runId ?? Guid.NewGuid().ToString(), _parentRunId, extraParams);
                    }
                    else if (handler is IHandleLLMStart handleLLMStartHandler)
                    {
                        messageStrings = messages.Select(x => GetBufferString(x)).ToList();
                        await handleLLMStartHandler.HandleLLMStart(llm, messageStrings, runId ?? Guid.NewGuid().ToString(), _parentRunId, extraParams);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error in handler {handler.GetType().Name}, HandleLLMStart: {ex}");
                }*/
            }
        }

        return new CallbackManagerForLlmRun(runId, Handlers, InheritableHandlers, _parentRunId);
    }

    public async Task<CallbackManagerForChainRun> HandleChainStart(
        BaseChain chain,
        ChainValues inputs,
        string? runId = null)
    {
        foreach (var handler in Handlers)
        {
            //TODO: Implement methods
            // if (!handler.IgnoreChain)
            // {
            //     try
            //     {
            //         await handler.HandleChainStart(chain, inputs, runId ?? Guid.NewGuid().ToString(), _parentRunId);
            //     }
            //     catch (Exception ex)
            //     {
            //         Console.Error.WriteLine($"Error in handler {handler.GetType().Name}, HandleChainStart: {ex}");
            //     }
            // }
        }

        return new CallbackManagerForChainRun(runId, Handlers, InheritableHandlers, _parentRunId);
    }

    public void AddHandler(BaseCallbackHandler handler, bool inherit = true)
    {
        Handlers.Add(handler);
        if (inherit)
        {
            InheritableHandlers.Add(handler);
        }
    }

    public void AddHandler(BaseCallbackHandler handler)
    {
        throw new NotImplementedException();
    }

    public void RemoveHandler(BaseCallbackHandler handler)
    {
        Handlers.Remove(handler);
        InheritableHandlers.Remove(handler);
    }

    public void SetHandlers(IEnumerable<BaseCallbackHandler> handlers)
    {
        Handlers = handlers.ToList();
    }

    public void SetHandlers(List<BaseCallbackHandler> handlers, bool inherit = true)
    {
        Handlers.Clear();
        InheritableHandlers.Clear();
        foreach (var handler in handlers)
        {
            AddHandler(handler, inherit);
        }
    }

    public CallbackManager Copy(List<BaseCallbackHandler>? additionalHandlers = null, bool inherit = true)
    {
        var manager = new CallbackManager(_parentRunId);
        foreach (var handler in Handlers)
        {
            var inheritable = InheritableHandlers.Contains(handler);
            manager.AddHandler(handler, inheritable);
        }
        if (additionalHandlers != null)
        {
            foreach (var handler in additionalHandlers)
            {
                if (manager.Handlers.Any(h => h.Name == "console_callback_handler" && h.Name == handler.Name))
                {
                    continue;
                }
                manager.AddHandler(handler, inherit);
            }
        }
        return manager;
    }

    public static CallbackManager FromHandlers(List<Handler> handlers)
    {
        var manager = new CallbackManager();

        foreach (var handler in handlers)
        {
            manager.AddHandler(handler);            
        }

        return manager;
    }

    public static async Task<CallbackManager> Configure(
        List<BaseCallbackHandler>? inheritableHandlers = null,
        List<BaseCallbackHandler>? localHandlers = null,
        ICallbackManagerOptions? options = null)
    {
        CallbackManager callbackManager = null;
        if (inheritableHandlers != null || localHandlers != null)
        {
            if (inheritableHandlers is List<BaseCallbackHandler> || inheritableHandlers == null)
            {
                callbackManager = new CallbackManager();
                callbackManager.SetHandlers(inheritableHandlers?.Cast<BaseCallbackHandler>().ToList() ?? new List<BaseCallbackHandler>(), true);
            }
            
            callbackManager = callbackManager.Copy(
                localHandlers,
                false);
        }
        var verboseEnabled = (Environment.GetEnvironmentVariable("LANGCHAIN_VERBOSE") != null || options?.Verbose == true);
        var tracingV2Enabled = (Environment.GetEnvironmentVariable("LANGCHAIN_TRACING_V2") != null);
        var tracingEnabled = tracingV2Enabled || (Environment.GetEnvironmentVariable("LANGCHAIN_TRACING") != null);
        if (verboseEnabled || tracingEnabled)
        {
            if (callbackManager == null)
            {
                callbackManager = new CallbackManager();
            }
            //TODO: Implement handlers
            /*if (!callbackManager.Handlers.Any(h => h.Name == ConsoleCallbackHandler.Name))
            {
                var consoleHandler = new ConsoleCallbackHandler();
                callbackManager.AddHandler(consoleHandler, true);
            }
            if (!callbackManager.Handlers.Any(h => h.Name == "langchain_tracer"))
            {
                if (tracingV2Enabled)
                {
                    callbackManager.AddHandler(await GetTracingV2CallbackHandler(), true);
                }
                else
                {
                    var session = Environment.GetEnvironmentVariable("LANGCHAIN_SESSION");
                    callbackManager.AddHandler(await GetTracingCallbackHandler(session), true);
                }
            }*/
        }
        return callbackManager;
    }

    private static string GetBufferString(List<BaseChatMessage> messages)
    {
        // Implement your logic here to convert messages to a string
        throw new NotImplementedException();
    }

    public Task HandleLlmStartAsync(Dictionary<string, object> llm, string[] prompts, string runId, string? parentRunId = null,
        Dictionary<string, object>? extraParams = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleLlmNewTokenAsync(string token, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleLlmErrorAsync(Exception err, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleLlmEndAsync(LlmResult output, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleChatModelStartAsync(Dictionary<string, object> llm, List<List<object>> messages, string runId, string? parentRunId = null,
        Dictionary<string, object>? extraParams = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleChainStartAsync(Dictionary<string, object> chain, Dictionary<string, object> inputs, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleChainErrorAsync(Exception err, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleChainEndAsync(Dictionary<string, object> outputs, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleToolStartAsync(Dictionary<string, object> tool, string input, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleToolErrorAsync(Exception err, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleToolEndAsync(string output, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleTextAsync(string text, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleAgentActionAsync(Dictionary<string, object> action, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }

    public Task HandleAgentEndAsync(Dictionary<string, object> action, string runId, string? parentRunId = null)
    {
        throw new NotImplementedException();
    }
}