﻿// ---------------------------------------------------------------------------
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

namespace LangChain.NET.LLMS.OpenAi;

public class OpenAIInput
{
    /// <summary>
    ///  Sampling temperature to use
    /// </summary>
    public decimal Temperature { get; set; }
    
    public decimal MaxTokens { get; set; }
    
    public decimal TopP { get; set; }
    
    public decimal FrequencyPenalty { get; set; }
    
    public decimal PresencePenalty { get; set; }
    
    public decimal N { get; set; }
    
    public decimal BestOf { get; set; }
    
    public Dictionary<string, decimal>? LogItBias { get; set; }
    
    public bool Streaming { get; set; }
    
    public string ModelName { get; set; }
    
    public object[] Kwargs { get; set; }
    
    public decimal BatchSize { get; set; }
    
    public string[] Stop { get; set; }
    
    public decimal? Timeout { get; set; }
}