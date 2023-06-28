namespace LangChain.NET.Schema;

public class AiChatMessage : BaseChatMessage
{
    public AiChatMessage(string text) : base(text){}
    
    public override MessageType GetType() => MessageType.Ai;
}