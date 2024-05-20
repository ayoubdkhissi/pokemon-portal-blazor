using pokemon_portal_blazor.DTOs;
using System.Net.Http.Json;

namespace pokemon_portal_blazor.Services;

public class PokemonService : IPokemonService
{
    private const string PATH = "/pokemon";

    private readonly HttpClient _httpClient;

    public PokemonService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<SearchResponse<PokemonDto>>> SearchAsync(SearchRequest searchRequest)
    {
        return await _httpClient.GetFromJsonAsync<ApiResponse<SearchResponse<PokemonDto>>>(
                       $"{PATH}/search?searchTerm={searchRequest.SearchTerm}?pageNumber={searchRequest.PageNumber}?pageSize={searchRequest.PageSize}") ?? new();
    }
}

