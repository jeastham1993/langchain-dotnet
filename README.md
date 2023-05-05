# 🦜️🔗 LangChain .NET

⚡ Building applications with LLMs through composability ⚡

## 🤔 What is this?

This is the .NET language implementation of LangChain.

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