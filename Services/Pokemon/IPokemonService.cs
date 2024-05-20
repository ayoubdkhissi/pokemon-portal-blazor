using pokemon_portal_blazor.DTOs;

namespace pokemon_portal_blazor.Services;

public interface IPokemonService
{
    Task<ApiResponse<SearchResponse<PokemonDto>>> SearchAsync(SearchRequest searchRequest);
}

