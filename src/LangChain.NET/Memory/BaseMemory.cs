using LangChain.NET.Schema;

namespace LangChain.NET.Memory;

public abstract class BaseMemory
{
    public abstract OutputValues LoadMemoryVariables(InputValues inputValues);
    public abstract void SaveContext(InputValues inputValues, OutputValues outputValues);
}