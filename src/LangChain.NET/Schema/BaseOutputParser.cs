namespace LangChain.NET.Schema;

public abstract class BaseOutputParser
{
    public abstract object Parse(string text);
}