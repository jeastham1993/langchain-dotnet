using System.Text.Json;
using LangChain.NET.Prompts.Base;
using LangChain.NET.Schema;

namespace LangChain.NET.Prompts;

public class SerializedMessagePromptTemplate
{
    public string Type { get; set; } = "message";
    public List<string> InputVariables { get; set; }

    // Additional properties are handled by a dictionary
    public Dictionary<string, object> AdditionalProperties { get; set; } = new Dictionary<string, object>();
}


public abstract class BaseMessagePromptTemplate
{
    public abstract List<string> InputVariables { get; }

    public abstract Task<List<BaseChatMessage>> FormatMessages(InputValues values);

    public SerializedMessagePromptTemplate Serialize()
    {
        var serialized = new SerializedMessagePromptTemplate
        {
            Type = this.GetType().Name,
            // You need to serialize 'this' to a JSON string, then deserialize it back to a dictionary
            // to mimic the JavaScript `JSON.parse(JSON.stringify(this))` behavior.
            AdditionalProperties = JsonSerializer.Deserialize<Dictionary<string, object>>(
                JsonSerializer.Serialize(this))
        };
        return serialized;
    }
}

public class ChatPromptValue : BasePromptValue
{
    public BaseChatMessage[] Messages { get; set; }

    public ChatPromptValue(BaseChatMessage[] messages)
    {
        this.Messages = messages;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this.Messages);
    }

    public override BaseChatMessage[] ToChatMessages()
    {
        return this.Messages;
    }
}

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

public abstract class BaseMessageStringPromptTemplate : BaseMessagePromptTemplate
{
    public BaseStringPromptTemplate Prompt { get; set; }

    protected BaseMessageStringPromptTemplate(BaseStringPromptTemplate prompt)
    {
        this.Prompt = prompt;
    }

    public override List<string> InputVariables => this.Prompt.InputVariables;

    public abstract Task<BaseChatMessage> Format(InputValues values);

    public override async Task<List<BaseChatMessage>> FormatMessages(InputValues values)
    {
        return new List<BaseChatMessage> { await this.Format(values) };
    }
}

public abstract class BaseChatPromptTemplate : BasePromptTemplate
{
    protected BaseChatPromptTemplate(IBasePromptTemplateInput input) : base(input) { }

    public abstract Task<BaseChatMessage[]> FormatMessages(InputValues values);

    public override async Task<string> Format(InputValues values)
    {
        return (await this.FormatPromptValue(values)).ToString();
    }

    public override async Task<BasePromptValue> FormatPromptValue(InputValues values)
    {
        var resultMessages = await this.FormatMessages(values);
        return new ChatPromptValue(resultMessages);
    }
}

public class ChatMessagePromptTemplate : BaseMessageStringPromptTemplate
{
    public string Role { get; set; }

    public ChatMessagePromptTemplate(BaseStringPromptTemplate prompt, string role) : base(prompt)
    {
        this.Role = role;
    }

    public override async Task<BaseChatMessage> Format(InputValues values)
    {
        return new ChatMessage(await this.Prompt.Format(values));
    }

    public static ChatMessagePromptTemplate FromTemplate(string template, string role)
    {
        return new ChatMessagePromptTemplate(PromptTemplate.FromTemplate(template), role);
    }
}

public class HumanMessagePromptTemplate : BaseMessageStringPromptTemplate
{
    public HumanMessagePromptTemplate(BaseStringPromptTemplate prompt) : base(prompt) { }

    public override async Task<BaseChatMessage> Format(InputValues values)
    {
        return new HumanChatMessage(await this.Prompt.Format(values));
    }

    public static HumanMessagePromptTemplate FromTemplate(string template)
    {
        return new HumanMessagePromptTemplate(PromptTemplate.FromTemplate(template));
    }
}

public class AIMessagePromptTemplate : BaseMessageStringPromptTemplate
{
    public AIMessagePromptTemplate(BaseStringPromptTemplate prompt) : base(prompt) { }

    public override async Task<BaseChatMessage> Format(InputValues values)
    {
        return new AiChatMessage(await this.Prompt.Format(values));
    }

    public static AIMessagePromptTemplate FromTemplate(string template)
    {
        return new AIMessagePromptTemplate(PromptTemplate.FromTemplate(template));
    }
}

public class SystemMessagePromptTemplate : BaseMessageStringPromptTemplate
{
    public SystemMessagePromptTemplate(BaseStringPromptTemplate prompt) : base(prompt) { }

    public override async Task<BaseChatMessage> Format(InputValues values)
    {
        return new SystemChatMessage(await this.Prompt.Format(values));
    }

    public static SystemMessagePromptTemplate FromTemplate(string template)
    {
        return new SystemMessagePromptTemplate(PromptTemplate.FromTemplate(template));
    }
}

public class ChatPromptTemplateInput : IBasePromptTemplateInput
{
    public List<BaseMessagePromptTemplate> PromptMessages { get; set; }

    public bool ValidateTemplate { get; set; } = true;
    public List<string> InputVariables { get; set; } = new();
    public Dictionary<string, object> PartialVariables { get; set; } = new();
}

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

