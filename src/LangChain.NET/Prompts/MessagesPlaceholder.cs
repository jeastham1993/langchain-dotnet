using LangChain.NET.Schema;

namespace LangChain.NET.Prompts;

public class MessagesPlaceholder : BaseMessagePromptTemplate
{
    public string VariableName { get; set; }

    public MessagesPlaceholder(string variableName)
    {
        this.VariableName = variableName;
    }

    public override List<string> InputVariables => new List<string> { this.VariableName };

    public override Task<List<BaseChatMessage>> FormatMessages(InputValues values)
    {
        return Task.FromResult(values[this.VariableName]);
    }
}