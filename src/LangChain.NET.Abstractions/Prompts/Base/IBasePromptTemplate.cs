using LangChain.NET.Abstractions.Schema;

namespace LangChain.NET.Abstractions.Prompts.Base;

/// <summary>
/// Base interface for all prompt templates, returning a prompt.
/// </summary>
/// <see cref="https://api.python.langchain.com/en/latest/modules/prompts.html#langchain.prompts.BasePromptTemplate"/>
public interface IBasePromptTemplate
{
    /// <summary>
    /// Format the prompt with the inputs.
    /// </summary>
    /// <returns>A formatted string.</returns>
    /// <see cref="https://api.python.langchain.com/en/latest/modules/prompts.html#langchain.prompts.BasePromptTemplate.format"/>
    Task<string> FormatAsync(IReadOnlyDictionary<string, object> args);
    
    /// <summary>
    /// Create Chat Messages.
    /// </summary>
    /// <returns></returns>
    Task<IPromptValue> FormatPromptAsync(IReadOnlyDictionary<string, object> args);

    /// <summary>
    /// Return a partial of the prompt template.
    /// </summary>
    /// <returns></returns>
    Task<IBasePromptTemplate> PartialAsync();
}