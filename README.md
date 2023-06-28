**IMPORTANT! This package is currently in an early alpha preview, please provide any feedback via GitHub issues.**

[![NuGet](https://img.shields.io/nuget/vpre/langchain.net.svg)](https://www.nuget.org/packages/LangChain.NET)

# 🦜️🔗 LangChain .NET

⚡ Building applications with LLMs through composability ⚡

## 🤔 What is this?

This is the .NET language implementation of LangChain.

### Installing LangChain.NET

You should install [LangChain.NET with NuGet](https://www.nuget.org/packages/LangChain.NET/):

    Install-Package LangChain.NET
    
Or via the .NET Core command line interface:

    dotnet add package LangChain.NET

Either commands, from Package Manager Console or .NET Core CLI, will download and install LangChain.NET and all required dependencies.

## 🎉 Examples

See [examples](./examples) for example usage.

```c#
var model = new OpenAI();

var result = await model.Call("What is a good name for a company that sells colourful socks?");

Console.WriteLine(result);
```
```shell
$ dotnet run .

Socktastic!
```

Or using chains

```c#
var llm = new OpenAi();

var template = "What is a good name for a company that makes {product}?";
var prompt = new PromptTemplate<string>(new PromptTemplateInput<string>()
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
```
```shell
$ dotnet run .

Socktastic!
```