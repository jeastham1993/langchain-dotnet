using LangChain.NET.Schema;

namespace LangChain.NET.Prompts.Base;

public abstract class BasePromptTemplate : BasePromptTemplateInput
{
    public BasePromptTemplate(BasePromptTemplateInput input)
    {
        this.PartialValues = input.PartialValues;
        this.InputVariables = input.InputVariables;
        this.OutputParser = input.OutputParser;
    }
    
    public string[] InputVariables { get; set; }
    public BaseOutputParser OutputParser { get; set; }
    public PartialValues PartialValues { get; set; }

    public abstract BasePromptTemplate Partial(PartialValues partial);
}