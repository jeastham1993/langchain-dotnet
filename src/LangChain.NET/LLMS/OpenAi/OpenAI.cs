using System.Text;
using System.Text.Json;
using LangChain.NET.Schema;
using Microsoft.DeepDev;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LangChain.NET.LLMS.OpenAi;

public class OpenAi : BaseLlm, IDisposable
{
    private readonly OpenAiConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly bool _disposeHttpClient;

    public OpenAi() : this (new OpenAiConfiguration())
    {
    }
    
    [ActivatorUtilitiesConstructor]
    public OpenAi(IOptions<OpenAiConfiguration> options, HttpClient httpClient) : this(options.Value, httpClient)
    {
    }
    
    public OpenAi(OpenAiConfiguration configuration, HttpClient? httpClient = null) : base(configuration)
    {
        _configuration = configuration;

        if (string.IsNullOrEmpty(_configuration.ApiKey))
        {
            _configuration.ApiKey = Environment.GetEnvironmentVariable("OPEN_AI_API_KEY") ?? throw new ArgumentException("'OPEN_AI_API_KEY' environment variable is not set and an API key is not provided in the input parameters");
        }

        if (httpClient == null)
        {
            _disposeHttpClient = true;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.openai.com/v1");
        }
        else
        {
            _httpClient = httpClient;
        }
        
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
    public override string LlmType { get; set; }
    public override TikTokenizer Tokenizer { get; set; }

    public override async Task<LlmResult> Generate(string[] prompts, List<string>? stop)
    {
        var choices = new List<Choices>();
        var usage = new List<Usage>();

        foreach (var prompt in prompts)
        {
            var result = await _httpClient.PostAsync("https://api.openai.com/v1/completions", new StringContent(JsonSerializer.Serialize(new
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
                stop = stop is { Count: 0 } ? null : stop,
                stream = _configuration.Streaming,
            }), Encoding.UTF8, "application/json"));

            if (!result.IsSuccessStatusCode)
            {
                Console.WriteLine(await result.Content.ReadAsStringAsync());
                throw new Exception("HTTP Exception");
            }

            var response = JsonSerializer.Deserialize<OpenAiCompletionResponse>(await result.Content.ReadAsStreamAsync());

            choices.AddRange(response.Choices);
            usage.Add(response.Usage);
        }
        
        return new LlmResult
        {
            Generations = choices.Select(choice => new Generation()
            {
                Text = choice.Text, GenerationInfo = new Dictionary<string, object>(1)
                {
                    { "finish_reason", choice.FinishReason }
                }
            }).ToArray(),
            LlmOutput = new Dictionary<string, object>(1)
            {
                {"usage", usage}
            }
        };
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!disposing) return;
        if (_disposeHttpClient)
        {
            _httpClient.Dispose();
        }
    }
}