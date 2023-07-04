namespace LangChain.NET.Memory
{
    public abstract class BaseMemory
    {
        public abstract string[] memoryKeys { get; }

        public abstract Task<MemoryVariables> LoadMemoryVariables(InputValues values);

        public abstract Task SaveContext(InputValues inputValues, OutputValues outputValues);
    }
}
