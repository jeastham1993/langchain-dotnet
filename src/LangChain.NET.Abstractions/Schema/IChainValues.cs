namespace LangChain.NET.Abstractions.Schema;

public interface IChainValues
{
    public Dictionary<string, object> Value { get; }
}