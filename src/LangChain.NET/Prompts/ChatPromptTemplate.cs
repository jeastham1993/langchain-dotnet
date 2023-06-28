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

public abstract class BaseMessageStringPromptTemplate<T> : BaseMessagePromptTemplate
{
    public BaseStringPromptTemplate<T> Prompt { get; set; }

    protected BaseMessageStringPromptTemplate(BaseStringPromptTemplate<T> prompt)
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

public abstract class BaseChatPromptTemplate<T> : BasePromptTemplate<T>
{
    protected BaseChatPromptTemplate(IBasePromptTemplateInput<T> input) : base(input) { }

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

public class ChatMessagePromptTemplate<T> : BaseMessageStringPromptTemplate<T>
{
    public string Role { get; set; }

    public ChatMessagePromptTemplate(BaseStringPromptTemplate<T> prompt, string role) : base(prompt)
    {
        this.Role = role;
    }

    public override async Task<BaseChatMessage> Format(InputValues values)
    {
        return new ChatMessage(await this.Prompt.Format(values));
    }

    public static ChatMessagePromptTemplate<T> FromTemplate(string template, string role)
    {
        return new ChatMessagePromptTemplate<T>(PromptTemplate<T>.FromTemplate(template), role);
    }
}

public class HumanMessagePromptTemplate<T> : BaseMessageStringPromptTemplate<T>
{
    public HumanMessagePromptTemplate(BaseStringPromptTemplate<T> prompt) : base(prompt) { }

    public override async Task<BaseChatMessage> Format(InputValues values)
    {
        return new HumanChatMessage(await this.Prompt.Format(values));
    }

    public static HumanMessagePromptTemplate<T> FromTemplate(string template)
    {
        return new HumanMessagePromptTemplate<T>(PromptTemplate<T>.FromTemplate(template));
    }
}

public class AIMessagePromptTemplate<T> : BaseMessageStringPromptTemplate<T>
{
    public AIMessagePromptTemplate(BaseStringPromptTemplate<T> prompt) : base(prompt) { }

    public override async Task<BaseChatMessage> Format(InputValues values)
    {
        return new AiChatMessage(await this.Prompt.Format(values));
    }

    public static AIMessagePromptTemplate<T> FromTemplate(string template)
    {
        return new AIMessagePromptTemplate<T>(PromptTemplate<T>.FromTemplate(template));
    }
}

public class SystemMessagePromptTemplate<T> : BaseMessageStringPromptTemplate<T>
{
    public SystemMessagePromptTemplate(BaseStringPromptTemplate<T> prompt) : base(prompt) { }

    public override async Task<BaseChatMessage> Format(InputValues values)
    {
        return new SystemChatMessage(await this.Prompt.Format(values));
    }

    public static SystemMessagePromptTemplate<T> FromTemplate(string template)
    {
        return new SystemMessagePromptTemplate<T>(PromptTemplate<T>.FromTemplate(template));
    }
}

public class ChatPromptTemplateInput<T> : IBasePromptTemplateInput<T>
{
    public List<BaseMessagePromptTemplate> PromptMessages { get; set; }

    public bool ValidateTemplate { get; set; } = true;
    public List<string> InputVariables { get; set; } = new();
    public BaseOutputParser<T> OutputParser { get; set; }
    public Dictionary<string, object> PartialVariables { get; set; } = new();
}

public class ChatPromptTemplate<T> : BaseChatPromptTemplate<T>
{
    public List<BaseMessagePromptTemplate> PromptMessages { get; set; }

    public bool ValidateTemplate { get; set; }

    public ChatPromptTemplate(ChatPromptTemplateInput<T> input) : base(input)
    {
        this.PromptMessages = input.PromptMessages;
        this.ValidateTemplate = input.ValidateTemplate;

        if (this.ValidateTemplate)
        {
            // Add template validation logic here as needed.
        }
    }

    public override Task<BasePromptTemplate<T>> Partial(PartialValues values)
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
    
    
    public static ChatPromptTemplate<T> FromPromptMessages(List<BaseMessagePromptTemplate> promptMessages)
    {
        var flattenedMessages = new List<BaseMessagePromptTemplate>();

        foreach (var promptMessage in promptMessages)
        {
            if (promptMessage is ChatPromptTemplate<T> chatPromptTemplate)
            {
                flattenedMessages.AddRange(chatPromptTemplate.PromptMessages);
            }
            else
            {
                flattenedMessages.Add(promptMessage);
            }
        }

        var inputVariables = new HashSet<string>();

        return new ChatPromptTemplate<T>(new ChatPromptTemplateInput<T>())
        {
            InputVariables = inputVariables.ToList(),
            PromptMessages = flattenedMessages
        };
    }
}

