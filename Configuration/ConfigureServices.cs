using pokemon_portal_blazor.Services;

namespace pokemon_portal_blazor.Configuration;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPokemonService, PokemonService>();
        return services;
    }
}

