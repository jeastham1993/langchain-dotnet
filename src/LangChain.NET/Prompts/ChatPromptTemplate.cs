using LangChain.NET.Prompts.Base;
using LangChain.NET.Schema;

namespace LangChain.NET.Prompts;

public class ChatPromptTemplate : BaseChatPromptTemplate
{
    public List<BaseMessagePromptTemplate> PromptMessages { get; set; }

    public bool ValidateTemplate { get; set; }

    public ChatPromptTemplate(ChatPromptTemplateInput input) : base(input)
    {
        this.PromptMessages = input.PromptMessages;
        this.ValidateTemplate = input.ValidateTemplate;

        if (this.ValidateTemplate)
        {
            // Add template validation logic here as needed.
        }
    }

    public override Task<BasePromptTemplate> Partial(PartialValues values)
    {
        throw new NotImplementedException();
    }

    protected override string GetPromptType()
    {
        return "chat";
    }

    public override SerializedBasePromptTemplate Serialize()
    {
        throw new NotImplementedException();
    }

    public override async Task<BaseChatMessage[]> FormatMessages(InputValues values)
    {
        var allValues = await this.MergePartialAndUserVariables(values);

        var resultMessages = new List<BaseChatMessage>();

        foreach (var promptMessage in this.PromptMessages)
        {
            var inputValues = new InputValues();

            foreach (var inputVariable in promptMessage.InputVariables)
            {
                if (!allValues.Value.ContainsKey(inputVariable))
                {
                    throw new Exception($"Missing value for input variable `{inputVariable}`");
                }

                inputValues.Value.Add(inputVariable, allValues.Value[inputVariable]);
            }

            var message = await promptMessage.FormatMessages(inputValues);
            resultMessages.AddRange(message);
        }

        return resultMessages.ToArray();
    }
    
    
    public static ChatPromptTemplate FromPromptMessages(List<BaseMessagePromptTemplate> promptMessages)
    {
        var flattenedMessages = new List<BaseMessagePromptTemplate>();

        foreach (var promptMessage in promptMessages)
        {
            flattenedMessages.Add(promptMessage);
        }

        var inputVariables = new HashSet<string>();

        return new ChatPromptTemplate(new ChatPromptTemplateInput())
        {
            InputVariables = inputVariables.ToList(),
            PromptMessages = flattenedMessages
        };
    }
}

