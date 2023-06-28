namespace LangChain.NET.Schema;

public enum MessageType
{
    User,
    Ai,
    Generic,
    System
}

public abstract class BaseChatMessage
{
    public BaseChatMessage(string text)
    {
        Text = text;
    }
        
    public string Text { get; set; }
    
    public string? Name { get; set; }

    public abstract MessageType GetType();
}