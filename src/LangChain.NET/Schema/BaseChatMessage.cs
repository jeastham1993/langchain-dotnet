namespace LangChain.NET.Schema;

public enum MessageType
{
    human,
    ai,
    generic,
    system
}

public abstract class BaseChatMessage
{
    public BaseChatMessage(string text)
    {
        this.Text = text;
    }
        
    public string Text { get; set; }
    
    public string? Name { get; set; }

    public abstract MessageType GetType();
}