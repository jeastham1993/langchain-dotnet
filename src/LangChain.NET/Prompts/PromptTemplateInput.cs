using LangChain.NET.Schema;

namespace LangChain.NET.Prompts;

public class PromptTemplateInput : IPromptTemplateInput
{
    public string Template { get; set; }
    public TemplateFormatOptions? TemplateFormat { get; set; }

    public bool? ValidateTemplate { get; set; }

    public List<string> InputVariables { get; set; } = new();

    public Dictionary<string, object> PartialVariables { get; set; } = new();
}