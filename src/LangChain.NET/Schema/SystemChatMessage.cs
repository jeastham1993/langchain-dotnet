namespace LangChain.NET.Schema;

public class SystemChatMessage : BaseChatMessage
{
    public SystemChatMessage(string text) : base(text){}

    public override MessageType GetType() => MessageType.System;
}