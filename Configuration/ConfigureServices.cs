using pokemon_portal_blazor.Services;
using pokemon_portal_blazor.Services.Common;

namespace pokemon_portal_blazor.Configuration;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPokemonService, PokemonService>();
        services.AddScoped<LocalStorageService>();
        return services;
    }
}

