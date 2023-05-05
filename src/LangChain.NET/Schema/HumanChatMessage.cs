namespace LangChain.NET.Schema;

internal class HumanChatMessage : BaseChatMessage
{
    public HumanChatMessage(string text) : base(text){}
    
    public override MessageType GetType() => MessageType.human;
}