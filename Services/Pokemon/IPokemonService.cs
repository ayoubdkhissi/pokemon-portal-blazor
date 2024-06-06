using pokemon_portal_blazor.DTOs;

namespace pokemon_portal_blazor.Services;

public interface IPokemonService
{
    Task<SearchResponse<PokemonDto>> SearchAsync(SearchRequest searchRequest);
    Task<SearchResponse<PokemonDto>> GetMyPokemonsAsync(SearchRequest searchRequest);
    Task<bool> IsCapturedAsync(int id);
    Task CaptureAsync(PokemonDto pokemon);
    Task ReleaseAsync(int id);
    Task ReleaseAllAsync();
    Task<StatisticsModel?> GetStatisticsAsync();
}

