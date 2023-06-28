using System.Text;
using System.Text.Json;
using LangChain.NET.LLMS.OpenAi;
using LangChain.NET.Schema;
using Microsoft.DeepDev;

namespace LangChain.NET.LLMS.OpenAiChatModel;

public class OpenAiChatModel: BaseLlm
{
    private readonly OpenAiConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public OpenAiChatModel() : this (new OpenAiConfiguration())
    {
    }

    public OpenAiChatModel(OpenAiConfiguration configuration) : base(configuration)
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
    public override string LlmType { get; set; }
    public override TikTokenizer Tokenizer { get; set; }

    public override async Task<LlmResult> GeneratePrompt(BasePromptValue[] promptValues, List<string>? stop)
    {
        var choices = new List<ChatChoices>();
        var usage = new List<Usage>();

        var messages = new List<OpenAiChatMessage>();

        foreach (var prompt in promptValues)
        {
            var contents = prompt.ToChatMessages();

            foreach (var chatMessage in contents)
            {
                messages.Add(new OpenAiChatMessage()
                {
                    Role = chatMessage.GetType().ToString().ToLower(),
                    Content = chatMessage.Text
                });
            }
        }
        
        var result = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", new StringContent(JsonSerializer.Serialize(new
        {
            model = _configuration.ModelName,
            messages = messages,
            max_tokens = _configuration.MaxTokens,
            temperature = _configuration.Temperature,
            top_p = _configuration.TopP,
            frequency_penalty = _configuration.FrequencyPenalty,
            presence_penalty = _configuration.PresencePenalty,
            n = _configuration.N,
            logit_bias = _configuration.LogItBias,
            stop = stop is { Count: 0 } ? null : stop,
            stream = _configuration.Streaming,
        }), Encoding.UTF8, "application/json"));

        if (!result.IsSuccessStatusCode)
        {
            throw new Exception("HTTP Exception");
        }

        var response = JsonSerializer.Deserialize<OpenAiChatCompletionResponse>(await result.Content.ReadAsStreamAsync());

        choices.AddRange(response.Choices);
        usage.Add(response.Usage);
        
        return new LlmResult
        {
            Generations = choices.Select(choice => new Generation()
            {
                Text = choice.Message.Content, GenerationInfo = new Dictionary<string, object>(1)
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

    public override async Task<LlmResult> Generate(string[] prompts, List<string>? stop)
    {
        var choices = new List<Choices>();
        var usage = new List<Usage>();

        foreach (var prompt in prompts)
        {
            var result = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", new StringContent(JsonSerializer.Serialize(new
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
}