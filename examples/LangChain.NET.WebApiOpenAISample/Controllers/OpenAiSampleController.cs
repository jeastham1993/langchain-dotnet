using LangChain.NET.LLMS.OpenAi;
using Microsoft.AspNetCore.Mvc;

namespace LangChain.NET.WebApiOpenAISample.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenAiSampleController : ControllerBase
{
    private readonly OpenAi _openAi;
    private readonly ILogger<OpenAiSampleController> _logger;

    public OpenAiSampleController(OpenAi openAi, ILogger<OpenAiSampleController> logger)
    {
        _openAi = openAi;
        _logger = logger;
    }

    [HttpGet(Name = "GetResponse")]
    public async Task<string?> Get()
    {
        return await _openAi.Call("What is a good name for a company that sells colourful socks?");
    }
}