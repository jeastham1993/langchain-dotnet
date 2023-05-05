
using LangChain.NET.LLMS.HuggingFace;
using LangChain.NET.LLMS.OpenAi;

Console.WriteLine("What is your OpenAI API Key?");
var model = new OpenAI(new OpenAIConfiguration()
{
    ApiKey = Console.ReadLine(),
    ModelName = "text-davinci-003",
    Temperature = 1.0M,
    MaxTokens = 1000,
});

Console.WriteLine("What is your Hugging Face API Key?");
var secondModel = new HuggingFace(new HuggingFaceConfiguration()
{
    ApiKey = Console.ReadLine(),
    ModelName = "gpt2",
    Temperature = 0.9M
});

var result = await model.Call("Write me a limerick about generative AI?");

Console.WriteLine(result);

var hfResult = await secondModel.Call("The man walked his");

Console.WriteLine(hfResult);