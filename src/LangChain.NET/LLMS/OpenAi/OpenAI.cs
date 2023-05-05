using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json;
using LangChain.NET.Base;
using LangChain.NET.Schema;
using Microsoft.DeepDev;

namespace LangChain.NET.LLMS.OpenAi;

public class OpenAI : BaseLLM
{
    private readonly OpenAIConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public OpenAI() : this (new OpenAIConfiguration())
    {
    }

    public OpenAI(OpenAIConfiguration configuration) : base(configuration)
    {
        _configuration = configuration;

        if (string.IsNullOrEmpty(_configuration.ApiKey))
        {
            _configuration.ApiKey = Environment.GetEnvironmentVariable("OPEN_AI_API_KEY") ?? throw new ArgumentException("'OPEN_AI_API_KEY' environment variable is not set and an API key is not provided in the input parameters");
        }

        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://api.openai.com/v1");
            
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_configuration.ApiKey}");

        if (_configuration.Streaming && _configuration.N > 1)
        {
            throw new ArgumentException("Cannot stream results when n > 1");
        }
        
        if (_configuration.Streaming && _configuration.BestOf > 1)
        {
            throw new ArgumentException("Cannot stream results when bestOf > 1");
        }
    }

    public override string ModelType { get; set; }
    public override string LLMType { get; set; }
    public override TikTokenizer Tokenizer { get; set; }

    public override async Task<LLMResult> Generate(string[] prompts, string[]? stop)
    {
        var choices = new List<Choices>();
        var usage = new List<Usage>();

        foreach (var prompt in prompts)
        {
            var result = await this._httpClient.PostAsync("https://api.openai.com/v1/completions", new StringContent(JsonSerializer.Serialize(new
            {
                model = _configuration.ModelName,
                prompt = prompt,
                max_tokens = _configuration.MaxTokens,
                temperature = _configuration.Temperature,
                top_p = _configuration.TopP,
                frequency_penalty = _configuration.FrequencyPenalty,
                presence_penalty = _configuration.PresencePenalty,
                n = _configuration.N,
                best_of = _configuration.BestOf,
                logit_bias = _configuration.LogItBias,
                stop = stop,
                stream = _configuration.Streaming,
            }), Encoding.UTF8, "application/json"));

            if (!result.IsSuccessStatusCode)
            {
                Console.WriteLine(await result.Content.ReadAsStringAsync());
                throw new Exception("HTTP Exception");
            }

            var response = JsonSerializer.Deserialize<OpenAICompletionResponse>(await result.Content.ReadAsStreamAsync());

            choices.AddRange(response.choices);
            usage.Add(response.usage);
        }
        
        return new LLMResult
        {
            Generations = choices.Select(choice => new Generation()
            {
                Text = choice.text, GenerationInfo = new Dictionary<string, object>(1)
                {
                    { "finish_reason", choice.finish_reason }
                }
            }).ToArray(),
            LLMOutput = new Dictionary<string, object>(1)
            {
                {"usage", usage}
            }
        };
    }
}