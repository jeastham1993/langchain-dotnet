using LangChain.NET.Abstractions.Schema;

namespace LangChain.NET.Abstractions.Chains.Base;

public interface IChain
{
    string[] InputKeys { get; }
    string[] OutputKeys { get; }
    Task<IChainValues> CallAsync(IChainValues chainValues);
}