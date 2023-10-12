using LangChain.NET.Chat;
using LangChain.NET.Schema;

namespace LangChain.NET.Memory;

public class BufferMemory : BaseChatMemory
{
    public BufferMemory(BufferMemoryInput input) : base(input)
    {
    }

    public override OutputValues LoadMemoryVariables(InputValues? inputValues)
    {
        return new OutputValues(new Dictionary<string, object> { { "history", ChatHistory } });
    }
}