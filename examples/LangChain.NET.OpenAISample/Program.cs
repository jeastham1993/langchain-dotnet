
using LangChain.NET.LLMS.OpenAi;

var model = new OpenAi();

var result = await model.Call("What is a good name for a company that sells colourful socks?");

Console.WriteLine(result);

