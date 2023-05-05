# 🦜️🔗 LangChain .NET

⚡ Building applications with LLMs through composability ⚡

## 🤔 What is this?

This is the .NET language implementation of LangChain.

## 🎉 Examples

See [examples](./examples) for example usage.

```c#
Console.WriteLine("What is your OpenAI API Key?");
var model = new OpenAI(new OpenAIConfiguration()
{
    ApiKey = Console.ReadLine(),
    ModelName = "text-davinci-003",
    Temperature = 1.0M,
    MaxTokens = 1000,
});

var result = await model.Call("What would be a good company name for a company that makes colorful socks");

Console.WriteLine(result);
```
```shell
$ dotnet run .

Socktastic!
```