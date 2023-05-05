// ---------------------------------------------------------------------------
// <copyright file="OpenAIInput.cs" company="BP p.l.c.">
// ---------------------------------------------------------------------------
// Copyright 2023 BP p.l.c. All Rights Reserved.
// Also protected by the Digital Millennium Copyright Act (DMCA) and
// afforded all remedies allowed under 17 U.S.C. § 1203.
// Proprietary and Confidential information of BP p.l.c.
// Disclosure, Use, or Reproduction without the written authorization
// of BP p.l.c. is prohibited.
// ---------------------------------------------------------------------------
// Author: Eastham, James
// ---------------------------------------------------------------------------
// </copyright>
// ---------------------------------------------------------------------------

using LangChain.NET.Cache;

namespace LangChain.NET.LLMS.OpenAi;

public class OpenAIConfiguration : BaseLLMParams
{
    public OpenAIConfiguration()
    {
        this.Temperature = 0.7M;
        this.MaxTokens = 256;
        this.TopP = 1;
        this.FrequencyPenalty = 0;
        this.PresencePenalty = 0;
        this.N = 1;
        this.BestOf = 1;
        this.LogItBias = new Dictionary<string, decimal>();
        this.ModelName = "text-davinci-003";
        this.BatchSize = 20;
    }
    
    /// <summary>
    ///  Sampling temperature to use
    /// </summary>
    public decimal Temperature { get; set; }
    
    /// <summary>
    /// Maximum number of tokens to generate in the completion. -1 returns as many
    /// tokens as possible given the prompt and the model's maximum context size.
    /// </summary>
    public decimal MaxTokens { get; set; }
    
    /// <summary>
    /// Total probability mass of tokens to consider at each step
    /// </summary>
    public decimal TopP { get; set; }
    
    /// <summary>
    /// Penalizes repeated tokens according to frequency
    /// </summary>
    public decimal FrequencyPenalty { get; set; }
    
    /// <summary>
    /// Penalizes repeated tokens
    /// </summary>
    public decimal PresencePenalty { get; set; }
    
    /// <summary>
    /// Number of completions to generate for each prompt
    /// </summary>
    public decimal N { get; set; }
    
    /// <summary>
    /// Generates `bestOf` completions server side and returns the "best"
    /// </summary>
    public decimal BestOf { get; set; }
    
    /// <summary>
    /// Dictionary used to adjust the probability of specific tokens being generatedDictionary used to adjust the probability of specific tokens being generated
    /// </summary>
    public Dictionary<string, decimal>? LogItBias { get; set; }
    
    /// <summary>
    /// Whether to stream the results or not. Enabling disables tokenUsage reporting
    /// </summary>
    public bool Streaming { get; set; }
    
    /// <summary>
    /// Model name to use
    /// </summary>
    public string ModelName { get; set; }
    
    /// <summary>
    /// Holds any additional parameters that are valid to pass to {@link
    /// https://platform.openai.com/docs/api-reference/completions/create |
    /// `openai.createCompletion`} that are not explicitly specified on this class.
    /// </summary>
    public object[] Kwargs { get; set; }

    /// <summary>
    /// Batch size to use when passing multiple documents to generate
    /// </summary>
    public decimal BatchSize { get; set; }
    
    /// <summary>
    /// List of stop words to use when generating
    /// </summary>
    public string[] Stop { get; set; }
    
    /// <summary>
    /// Timeout to use when making requests to OpenAI.
    /// </summary>
    public decimal? Timeout { get; set; }
    
    public bool? Verbose { get; set; }
    
    public decimal? Concurrency { get; set; }
    public BaseCache? Cache { get; set; }
    
    /// <summary>
    /// OpenAI API Key.
    /// </summary>
    public string ApiKey { get; set; }
}