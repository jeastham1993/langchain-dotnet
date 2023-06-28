
using System.Text.Json;
using LangChain.NET.Base;
using LangChain.NET.Callback;
using LangChain.NET.Chains.LLM;
using LangChain.NET.LLMS.OpenAi;
using LangChain.NET.LLMS.OpenAiChatModel;
using LangChain.NET.Prompts;
using LangChain.NET.Schema;

var llm = new OpenAi();

var template = "What is a good name for a company that makes {product}?";
var prompt = new PromptTemplate(new PromptTemplateInput()
{
    Template = template,
    InputVariables = new List<string>() { "product" }
});

var chain = new LlmChain<string>(new LlmChainInput<string>()
{
    Llm = llm,
    Prompt = prompt
});

var result = await chain.Call(new ChainValues(new Dictionary<string, object>(1)
{
    { "product", "colourful socks" }
}), new CallbackManagerForChainRun("", new List<BaseCallbackHandler>(), new List<BaseCallbackHandler>()));

// The result is an object with a `text` property.
Console.WriteLine(result.Value["text"]);

// Since the LLMChain is a single-input, single-output chain, we can also call it with `run`.
// This takes in a string and returns the `text` property.
var result2 = await chain.Run("colourful socks");

Console.WriteLine(result2);

// We can also construct an LLMChain from a ChatPromptTemplate and a chat model.
var chat = new OpenAiChatModel(new OpenAiConfiguration()
{
    ModelName = "gpt-3.5-turbo"
});

var chatPrompt = ChatPromptTemplate.FromPromptMessages(new List<BaseMessagePromptTemplate>(2)
{
    SystemMessagePromptTemplate.FromTemplate("You are a helpful assistant that translates {input_language} to {output_language}."),
    HumanMessagePromptTemplate.FromTemplate("{text}")
});

var chainB = new LlmChain<string>(new LlmChainInput<string>()
{
    Llm = chat,
    Prompt = chatPrompt
});

var resultB = await chainB.Call(new ChainValues(new Dictionary<string, object>(3)
{
    {"input_language", "English"},
    {"output_language", "French"},
    {"text", "I love programming"},
}), null);

Console.WriteLine(resultB.Value["text"]);