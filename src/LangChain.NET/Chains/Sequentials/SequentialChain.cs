using LangChain.NET.Abstractions.Chains.Base;
using LangChain.NET.Abstractions.Schema;
using LangChain.NET.Base;
using LangChain.NET.Schema;

namespace LangChain.NET.Chains.Sequentials;

public class SequentialChain : BaseChain
{
    public IChain[] Chains { get; }
    public override string[] InputKeys { get; }
    public override string[] OutputKeys { get; }
    public bool ReturnAll { get; }
    
    public SequentialChain(SequentialChainInput input)
    {
        Chains = input.Chains;
        InputKeys = input.InputVariables;
        OutputKeys = input.OutputVariables ?? Array.Empty<string>();
        ReturnAll = input.ReturnAll;
        
        Validate();
        
        if(OutputKeys.Length == 0 && !ReturnAll)
        {
            OutputKeys = Chains.Last().OutputKeys;
        }
        

    }
    
    public override string ChainType()
    {
        return "sequential_chain";
    }
    public override async Task<IChainValues> CallAsync(IChainValues values)
    {
        var allChainValues = values;

        foreach (var chain in Chains)
        {
            var input = await chain.CallAsync(allChainValues);

            foreach (var inputValue in input.Value)
            {
                allChainValues.Value.Add(inputValue.Key, inputValue.Value);
            }
        }

        if (ReturnAll)
        {
            foreach (var key in Chains.First().InputKeys)
            {
                allChainValues.Value.Remove(key);
            }
            return new ChainValues(allChainValues.Value.ToDictionary(_ => _.Key, _ => _.Value));
        }

        var output = new ChainValues();
        foreach (var outputKey in OutputKeys)
        {
            output.Value.Add(outputKey, allChainValues.Value[outputKey]);
        }

        return output;
    }

    protected virtual void Validate()
    {
        if (OutputKeys.Length > 0 && ReturnAll)
        {
            throw new ArgumentException(
                "Either specify variables to return using `outputVariables` or use `returnAll` param. Cannot apply both conditions at the same time.");
        }

        if (Chains.Length == 0)
        {
            throw new ArgumentException("Sequential chain must have at least one chain.");
        }
    }
}