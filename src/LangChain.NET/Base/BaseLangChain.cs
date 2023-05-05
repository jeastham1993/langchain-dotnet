namespace LangChain.NET.Base;

public interface BaseLangChainParams
{
    bool? Verbose { get; set; }
}

public abstract class BaseLangChain : BaseLangChainParams
{
    private const bool DEFAULT_VERBOSITY = false;
    
    public bool? Verbose { get; set; }

    public BaseLangChain(BaseLangChainParams parameters)
    {
        this.Verbose = parameters.Verbose ?? DEFAULT_VERBOSITY;
    }
}