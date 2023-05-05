using LangChain.NET.Schema;

namespace LangChain.NET.Prompts.Base;

public interface BasePromptTemplateInput
{
    public string[] InputVariables { get; set; }
    
    public BaseOutputParser OutputParser { get; set; }
    
    public PartialValues PartialValues { get; set; }
}