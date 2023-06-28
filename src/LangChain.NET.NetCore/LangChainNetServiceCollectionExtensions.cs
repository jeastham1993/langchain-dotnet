using LangChain.NET.LLMS.OpenAi;
using Microsoft.Extensions.DependencyInjection;

namespace LangChain.NET.NetCore;

public static class LangChainNetServiceCollectionExtensions
{
    public static IServiceCollection AddOpenAi(
        this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        var optionsBuilder = services.AddOptions<OpenAiConfiguration>();
        
        optionsBuilder.BindConfiguration("OpenAi");
        
        services.AddHttpClient<OpenAi>(httpClient =>
        {
            httpClient.BaseAddress = new Uri("https://api.openai.com/v1");
        });
        
        return services;
    }
}