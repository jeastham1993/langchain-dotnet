using LangChain.NET.Prompts.Base;
using LangChain.NET.Schema;

namespace LangChain.NET.Prompts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public abstract class ParsedFStringNode
{
    public string Type { get; }
    
    protected ParsedFStringNode(string type)
    {
        Type = type;
    }
}

public class LiteralNode : ParsedFStringNode
{
    public string Text { get; }
    
    public LiteralNode(string text) : base("literal")
    {
        Text = text;
    }
}

public class VariableNode : ParsedFStringNode
{
    public string Name { get; }
    
    public VariableNode(string name) : base("variable")
    {
        Name = name;
    }
}


public enum TemplateFormatOptions
{
    FString,
    Jinja2
}

public interface IPromptTemplateInput<T> : IBasePromptTemplateInput<T>
{
    string Template { get; set; }
    
    TemplateFormatOptions? TemplateFormat { get; set; }
    
    bool? ValidateTemplate { get; set; }
}

public class PromptTemplate<T> : BaseStringPromptTemplate<T>, IPromptTemplateInput<T>
{
    public string Template { get; set; }
    public TemplateFormatOptions? TemplateFormat { get; set; } = TemplateFormatOptions.FString;
    public bool? ValidateTemplate { get; set; } = true;
    
    public new Dictionary<string, object> PartialVariables { get; set; } = new();

    public PromptTemplate(IPromptTemplateInput<T> input)
        : base(input)
    {
        Template = input.Template;
        TemplateFormat = input.TemplateFormat ?? TemplateFormatOptions.FString;
        ValidateTemplate = input.ValidateTemplate ?? true;

        if (ValidateTemplate.Value)
        {
            var totalInputVariables = InputVariables.ToList();
            if (PartialVariables != null)
            {
                totalInputVariables.AddRange(PartialVariables.Keys);
            }

            CheckValidTemplate(Template, TemplateFormat.Value, totalInputVariables);
        }
    }

    protected override string GetPromptType()
    {
        return "prompt";
    }

    public override async Task<string> Format(InputValues values)
    {
        InputValues allValues = await MergePartialAndUserVariables(values);
        return RenderTemplate(Template, TemplateFormat.Value, allValues.Value);
    }

    public static PromptTemplate<T> FromExamples(
        IEnumerable<string> examples,
        string suffix,
        IEnumerable<string> inputVariables,
        string exampleSeparator = "\n\n",
        string prefix = "")
    {
        var template = $"{prefix}\n{string.Join(exampleSeparator, examples)}{suffix}";
        return new PromptTemplate<T>(new PromptTemplateInput<T>
        {
            InputVariables = inputVariables.ToList(),
            Template = template
        });
    }

    public static PromptTemplate<T> FromTemplate(string template, PromptTemplateInput<T>? options = null)
    {
        var names = new HashSet<string>();
        ParseTemplate(template, options?.TemplateFormat ?? TemplateFormatOptions.FString)
            .ForEach(node =>
            {
                if (node.Type == "variable")
                {
                    names.Add((node as VariableNode).Name);
                }
            });

        return new PromptTemplate<T>(new PromptTemplateInput<T>
        {
            InputVariables = names.ToList(),
            TemplateFormat = options?.TemplateFormat ?? TemplateFormatOptions.FString,
            Template = template
        });
    }

    public override async Task<BasePromptTemplate<T>> Partial(PartialValues values)
    {
        PromptTemplateInput<T> promptDict = new PromptTemplateInput<T>
        {
            Template = Template,
            TemplateFormat = TemplateFormat,
            ValidateTemplate = ValidateTemplate,
            InputVariables = InputVariables,
            OutputParser = OutputParser,
            PartialVariables = PartialVariables
        };

        promptDict.InputVariables = InputVariables
            .Where(iv => !values.Value.ContainsKey(iv))
            .ToList();

        if (PartialVariables != null)
        {
            foreach (var kvp in PartialVariables)
            {
                promptDict.PartialVariables[kvp.Key] = kvp.Value;
            }
        }

        foreach (var kvp in values.Value)
        {
            promptDict.PartialVariables[kvp.Key] = kvp.Value;
        }

        return new PromptTemplate<T>(promptDict);
    }

    public override SerializedPromptTemplate Serialize()
    {
        if (OutputParser != null)
        {
            throw new Exception("Cannot serialize a prompt template with an output parser");
        }

        return new SerializedPromptTemplate
        {
            InputVariables = InputVariables.ToList(),
            Template = Template,
        };
    }

    public static async Task<PromptTemplate<T>> Deserialize(SerializedPromptTemplate data)
    {
        if (string.IsNullOrEmpty(data.Template))
        {
            throw new Exception("Prompt template must have a template");
        }

        return new PromptTemplate<T>(new PromptTemplateInput<T>
        {
            InputVariables = data.InputVariables,
            Template = data.Template,
            // TemplateFormat = data.template_format
        });
    }

    public delegate string Interpolator(string template, Dictionary<string, object> inputValues);
    public delegate List<ParsedFStringNode> Parser(string template);

    public static Dictionary<TemplateFormatOptions, Interpolator> DefaultFormatterMapping = new Dictionary<TemplateFormatOptions, Interpolator>
    {
        { TemplateFormatOptions.FString, InterpolateFString },
        { TemplateFormatOptions.Jinja2, (_, __) => "" }
    };

    public static Dictionary<TemplateFormatOptions, Parser> DefaultParserMapping = new Dictionary<TemplateFormatOptions, Parser>
    {
        { TemplateFormatOptions.FString, ParseFString },
        { TemplateFormatOptions.Jinja2, _ => new List<ParsedFStringNode>() }
    };
    
    public static string InterpolateFString(string template, Dictionary<string, object> values)
    {
        List<ParsedFStringNode> nodes = ParseFString(template);
        return nodes.Aggregate("", (res, node) =>
        {
            if (node.Type == "variable")
            {
                var parsedNode = node as VariableNode;
                
                if (values.ContainsKey(parsedNode.Name))
                {
                    return res + values[parsedNode.Name];
                }
                
                throw new Exception($"Missing value for input {parsedNode.Name}");
            }

            return res + (node as LiteralNode).Text;
        });
    }
    
    public static List<ParsedFStringNode> ParseFString(string template)
    {
        // Core logic replicated from internals of pythons built in Formatter class.
        // https://github.com/python/cpython/blob/135ec7cefbaffd516b77362ad2b2ad1025af462e/Objects/stringlib/unicode_format.h#L700-L706
        List<char> chars = template.ToList();
        List<ParsedFStringNode> nodes = new List<ParsedFStringNode>();

        Func<string, int, int> nextBracket = (bracket, start) =>
        {
            for (int i = start; i < chars.Count; i++)
            {
                if (bracket.Contains(chars[i]))
                {
                    return i;
                }
            }
            return -1;
        };

        int i = 0;
        while (i < chars.Count)
        {
            if (chars[i] == '{' && i + 1 < chars.Count && chars[i + 1] == '{')
            {
                nodes.Add(new LiteralNode("{"));
                i += 2;
            }
            else if (chars[i] == '}' && i + 1 < chars.Count && chars[i + 1] == '}')
            {
                nodes.Add(new LiteralNode("}"));
                i += 2;
            }
            else if (chars[i] == '{')
            {
                int j = nextBracket("}", i);
                if (j < 0)
                {
                    throw new Exception("Unclosed '{' in template.");
                }

                nodes.Add(new VariableNode(new string(chars.GetRange(i + 1, j - (i + 1)).ToArray())));
                i = j + 1;
            }
            else if (chars[i] == '}')
            {
                throw new Exception("Single '}' in template.");
            }
            else
            {
                int next = nextBracket("{}", i);
                string text = next < 0 ? new string(chars.GetRange(i, chars.Count - i).ToArray()) : new string(chars.GetRange(i, next - i).ToArray());
                nodes.Add(new LiteralNode(text));
                i = next < 0 ? chars.Count : next;
            }
        }
        return nodes;
    }


    public static string RenderTemplate(string template, TemplateFormatOptions templateFormat, Dictionary<string, object> inputValues)
    {
        return DefaultFormatterMapping[templateFormat](template, inputValues);
    }

    
    public void CheckValidTemplate(string template, TemplateFormatOptions templateFormatOptions, List<string> inputVariables)
    {
        if (!DefaultFormatterMapping.ContainsKey(templateFormatOptions))
        {
            var validFormats = DefaultFormatterMapping.Keys;
            throw new Exception($"Invalid template format. Got `{templateFormatOptions}`; should be one of {string.Join(",", validFormats)}");
        }

        try
        {
            var dummyInputs = inputVariables.ToDictionary(v => v, v => new object());
            RenderTemplate(template, templateFormatOptions, dummyInputs);
        }
        catch
        {
            throw new Exception("Invalid prompt schema.");
        }
    }
    
    public static List<ParsedFStringNode> ParseTemplate(string template, TemplateFormatOptions templateFormat)
    {
        return DefaultParserMapping[templateFormat](template);
    }
}
