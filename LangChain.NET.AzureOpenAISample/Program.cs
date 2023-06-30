using LangChain.NET.LLMS.AzureOpenAi;

var model = new AzureOpenAi();

var result = await model.Call("What is a good name for a company that sells colourful socks?");

Console.WriteLine(result);

