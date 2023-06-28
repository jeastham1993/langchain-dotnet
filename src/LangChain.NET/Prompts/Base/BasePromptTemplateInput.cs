using LangChain.NET.Schema;

namespace LangChain.NET.Prompts.Base;

using System.Collections.Generic;

public interface IBasePromptTemplateInput<T>
{
    List<string> InputVariables { get; set; }
    BaseOutputParser<T> OutputParser { get; set; }
    Dictionary<string, object> PartialVariables { get; set; }
}
