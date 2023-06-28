namespace LangChain.NET.Schema;

public class ChatMessage : BaseChatMessage
{
    public ChatMessage(string text) : base(text){}

    
    public override MessageType GetType() => MessageType.Generic;
}