using LangChain.NET.Schema;

namespace LangChain.NET.Prompts.Base;

public class StringPromptValue : BasePromptValue
{
    public string Value { get; set; }


    public override BaseChatMessage[] ToChatMessages()
    {
        return new[] { new HumanChatMessage(this.Value) };
    }

    public override string ToString() => this.Value;
}