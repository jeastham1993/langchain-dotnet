using LangChain.NET.Prompts.Base;

namespace LangChain.NET.Prompts;

public interface IPromptTemplateInput : IBasePromptTemplateInput
{
    string Template { get; set; }
    
    TemplateFormatOptions? TemplateFormat { get; set; }
    
    bool? ValidateTemplate { get; set; }
}