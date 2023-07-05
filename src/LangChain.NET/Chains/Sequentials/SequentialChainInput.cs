using LangChain.NET.Abstractions.Chains.Base;
using LangChain.NET.Base;

namespace LangChain.NET.Chains.Sequentials;

public class SequentialChainInput
{
    public IChain[] Chains { get; }
    public string[] InputVariables { get; }
    
    public string[]? OutputVariables { get; } 
    
    public bool ReturnAll { get; }
    
    public SequentialChainInput(IChain[] chains, 
        string[] inputVariables, 
        string[]? outputVariables = null,
        bool returnAll = false)
    {
        Chains = chains;
        InputVariables = inputVariables;
        OutputVariables = outputVariables;
        ReturnAll = returnAll;
    }
    

}