
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

var result = await model.Call("Write me a limerick about generative AI?");

Console.WriteLine(result);

