using LangChain.NET.Chat;

namespace LangChain.NET.Memory
{
    public class ChatMessageHistory : BaseChatMessageHistory
    {
        public override void AddMessage(BaseChatMessage message)
        {
            Messages.Add(message);
        }

        public override void Clear()
        {
            Messages.Clear();
        }
    }
}