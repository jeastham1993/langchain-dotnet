
using LangChain.NET.LLMS.HuggingFace;

Console.WriteLine("What is your Hugging Face API Key?");

var secondModel = new HuggingFace(new HuggingFaceConfiguration()
{
    ApiKey = Console.ReadLine(),
    ModelName = "gpt2",
    Temperature = 0.9M
});

var hfResult = await secondModel.Call("The man walked his");

Console.WriteLine(hfResult);