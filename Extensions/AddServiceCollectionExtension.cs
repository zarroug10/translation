using Trasnlator.Interfaces;

namespace Trasnlator.Extensions;

public static class AddServiceCollectionExtension
{
    public static IServiceCollection AddServiceCollectionsExtensions(this IServiceCollection services, ConfigurationManager configuration)
    {
        //Add services to the container.
        services.AddHttpClient();
        services.AddScoped<ITranslationService, BasicTranslationService>();
        return services;
    }
}
