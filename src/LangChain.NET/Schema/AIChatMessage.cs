namespace LangChain.NET.Schema;

public class AIChatMessage : BaseChatMessage
{
    public AIChatMessage(string text) : base(text){}
    
    public override MessageType GetType() => MessageType.ai;
}