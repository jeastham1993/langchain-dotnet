
using LangChain.NET.LLMS.HuggingFace;

var huggingFace = new HuggingFace();

var hfResult = await huggingFace.Call("What would be a good company name be for name a company that makes colorful socks?");

Console.WriteLine(hfResult);