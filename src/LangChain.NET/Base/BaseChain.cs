using LangChain.NET.Callback;
using LangChain.NET.Chains;
using LangChain.NET.Schema;

namespace LangChain.NET.Base;

using System.Collections.Generic;
using LoadValues = Dictionary<string, object>;

public abstract class BaseChain
{
    const string RunKey = "__run";

    public abstract string ChainType();

    public abstract string[] InputKeys { get; }

    public abstract string[] OutputKeys { get; }

    public async Task<string> Run(string input, CallbackManagerForChainRun runManager = null)
    {
        var isKeylessInput = InputKeys.Length <= 1;

        if (!isKeylessInput)
        {
            throw new Exception($"Chain {ChainType()} expects multiple inputs, cannot use 'run'");
        }

        var values = InputKeys.Length > 0 ? new ChainValues(InputKeys[0], input) : new ChainValues();
        var returnValues = await Call(values, runManager);
        var keys = returnValues.Value.Keys;

        if (keys.Count(p => p != RunKey) == 1)
        {
            var returnValue = returnValues.Value.FirstOrDefault(p => p.Key != RunKey).Value;
            return returnValue == null ? null : returnValue.ToString();
        }

        throw new Exception("Return values have multiple keys, 'run' only supported when one key currently");
    }

    public async Task<ChainValues> Call(ChainValues values, BaseRunManager? runManager)
    {
        var fullValues = new ChainValues(values);

        //TODO: Implement memory
        // if (memory != null)
        // {
        //     var newValues = await memory.LoadMemoryVariables(values);
        //
        //     foreach (var entry in newValues)
        //     {
        //         fullValues[entry.Key] = entry.Value;
        //     }
        // }

        ChainValues outputValues;

        outputValues = await Call(fullValues);

        //TODO: implement memory
        // if (memory != null)
        // {
        //     await memory.SaveContext(values, outputValues);
        // }

        //TODO: Implement run manager
        //await runManager?.HandleChainEndAsync(outputValues);

        // Add the runManager's currentRunId to the outputValues
        outputValues.Value[RunKey] = runManager != null ? new { runId = runManager.RunId } : null;

        return outputValues;
    }

    protected abstract Task<ChainValues> Call(ChainValues values);
    
    public async Task<ChainValues> Apply(List<ChainValues> inputs, List<CallbackManagerForChainRun>? callbacks)
    {
        var tasks = inputs.Select(async (input, idx) => await Call(input, callbacks?[idx]));
        var results = await Task.WhenAll(tasks);

        return results.Aggregate(new ChainValues(), (acc, result) =>
        {
            foreach (var (key, value) in result.Value)
            {
                acc.Value[key] = value;
            }

            return acc;
        });
    }

    public static async Task<BaseChain> Deserialize(SerializedBaseChain data, LoadValues? values = null)
    {
        switch (data.Type)
        {
            case "llm_chain":
                {
                    var llmChainType = Type.GetType("Namespace.LLMChain"); // Replace with the actual namespace and class name
                    var deserializeMethod = llmChainType?.GetMethod("Deserialize");

                    return await (Task<BaseChain>)deserializeMethod.Invoke(null, new object[] { data });
                }
            case "sequential_chain":
                {
                    var sequentialChainType = Type.GetType("Namespace.SequentialChain"); // Replace with the actual namespace and class name
                    var deserializeMethod = sequentialChainType.GetMethod("Deserialize");

                    return await (Task<BaseChain>)deserializeMethod.Invoke(null, new object[] { data });
                }
            case "simple_sequential_chain":
                {
                    var simpleSequentialChainType = Type.GetType("Namespace.SimpleSequentialChain"); // Replace with the actual namespace and class name
                    var deserializeMethod = simpleSequentialChainType.GetMethod("Deserialize");

                    return await (Task<BaseChain>)deserializeMethod.Invoke(null, new object[] { data });
                }
            default:
                throw new Exception($"Invalid prompt type in config: {data.Type}");
        }
    }
}
