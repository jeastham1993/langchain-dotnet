namespace LangChain.NET.Schema;

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