namespace LangChain.NET.Memory
{
    public abstract class BaseChatMemory : BaseMemory
    {
        public ChatMessageHistory chatHistory;

        public abstract Task<MemoryVariables> loadMemoryVariables(InputValues values);
    }
}
