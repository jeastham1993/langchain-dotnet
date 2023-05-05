namespace LangChain.NET.Schema;

public abstract class BasePromptValue
{
    public abstract BaseChatMessage[] ToChatMessages();
    
    public abstract override string ToString();
}