using Azure;
using Azure.AI.OpenAI;
using LangChain.NET.Schema;
using Microsoft.DeepDev;

namespace LangChain.NET.LLMS.AzureOpenAi
{
    public class AzureOpenAi : BaseLlm
    {
        private readonly AzureOpenAiConfiguration _configuration;

        public AzureOpenAi() : this (new AzureOpenAiConfiguration())
        {
        }

        public AzureOpenAi(AzureOpenAiConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;

            if (string.IsNullOrEmpty(_configuration.ApiKey))
            {
                _configuration.ApiKey = Environment.GetEnvironmentVariable("AZURE_OPEN_AI_API_KEY") ?? throw new ArgumentException("'AZURE_OPEN_AI_API_KEY' environment variable is not set and an API key is not provided in the input parameters");
            }
            if (string.IsNullOrEmpty(_configuration.Endpoint))
            {
                _configuration.ApiKey = Environment.GetEnvironmentVariable("AZURE_OPEN_AI_ENDPOINT") ?? throw new ArgumentException("'AZURE_OPEN_AI_ENDPOINT' environment variable is not set and an API key is not provided in the input parameters");
            }
        }

        public override string ModelType { get; set; }
        public override string LlmType { get; set; }
        public override TikTokenizer Tokenizer { get; set; }

        public override async Task<LlmResult> Generate(string[] prompts, List<string>? stop)
        {
            var choices = new List<Choice>();
            var usage = new List<CompletionsUsage>();

            var client = new OpenAIClient(new Uri(_configuration.Endpoint), new AzureKeyCredential(_configuration.ApiKey));

            foreach (var prompt in prompts)
            {
                CompletionsOptions completionsOptions = new()
                {
                    Temperature = _configuration.Temperature,
                    MaxTokens = _configuration.MaxTokens,
                    LogProbabilityCount = _configuration.LogProbabilityCount,
                    NucleusSamplingFactor = _configuration.NucleusSamplingFactor,
                    PresencePenalty = _configuration.PresencePenalty
                };

                if (stop != null)
                {
                    foreach (var s in stop)
                    {
                        completionsOptions.StopSequences.Add(s);
                    }
                }

                completionsOptions.Prompts.Add(prompt);

                Response<Completions> completionsResponse = await client.GetCompletionsAsync(_configuration.ModelName, completionsOptions);

                choices.AddRange(completionsResponse.Value.Choices);
                usage.Add(completionsResponse.Value.Usage);

            }

            return new LlmResult
            {
                Generations = choices.Select(choice => new Generation()
                {
                    Text = choice.Text,
                    GenerationInfo = new Dictionary<string, object>(1)
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
            GC.SuppressFinalize(this);
        }
    }
}
