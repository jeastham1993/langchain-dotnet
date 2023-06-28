namespace LangChain.NET.Schema;

public class InputValues
{
    public Dictionary<string, object> Value { get; set; } = new();

    public List<BaseChatMessage> this[string variableName]
    {
        get { throw new NotImplementedException(); }
    }
}