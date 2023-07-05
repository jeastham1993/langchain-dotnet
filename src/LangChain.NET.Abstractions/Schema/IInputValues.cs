namespace LangChain.NET.Abstractions.Schema;

public interface IInputValues
{
    Dictionary<string, object> Value { get; }
}