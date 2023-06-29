using FluentAssertions;
using LangChain.NET.Base;
using LangChain.NET.Callback;
using LangChain.NET.Chains.LLM;
using LangChain.NET.LLMS.OpenAi;
using LangChain.NET.Prompts;
using LangChain.NET.Schema;

namespace LangChain.NET.IntegrationTests;

public class OpenAiTests
{
    [Fact]
    public async Task TestOpenAi_WithValidInput_ShouldReturnResponse()
    {
        var model = new OpenAi();

        var result = await model.Call("What is a good name for a company that sells colourful socks?");

        result.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task TestOpenAi_WithChain_ShouldReturnResponse()
    {
        var llm = new OpenAi();

        var template = "What is a good name for a company that makes {product}?";
        var prompt = new PromptTemplate(new PromptTemplateInput(template, new List<string>(1){"product"}));

        var chain = new LlmChain(new LlmChainInput(llm, prompt));

        var result = await chain.CallAsync(new ChainValues(new Dictionary<string, object>(1)
        {
            { "product", "colourful socks" }
        }));

        // The result is an object with a `text` property.
        result.Value["text"].ToString().Should().NotBeEmpty();
    }
}