using pokemon_portal_blazor.DTOs;
using pokemon_portal_blazor.Services.Common;
using System.Net.Http.Json;
using System.Text.Json;

namespace pokemon_portal_blazor.Services;

public class PokemonService : IPokemonService
{
    private const string PATH = "/api/pokemon";

    private readonly HttpClient _httpClient;
    private readonly LocalStorageService _localStorageService;
    public PokemonService(HttpClient httpClient, LocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }


    public async Task<SearchResponse<PokemonDto>> SearchAsync(SearchRequest searchRequest)
    {
        var apiResponse = await _httpClient.GetFromJsonAsync<ApiResponse<SearchResponse<PokemonDto>>>(
                       $"{PATH}/search?searchTerm={searchRequest.SearchTerm}&pageNumber={searchRequest.PageNumber}&pageSize={searchRequest.PageSize}") ?? new();

        var pokemonsSearchResponse = apiResponse.Data!;
        var localCapturedPokemons = await GetMyPokemonsAsync(searchRequest);

        // Update the IsCaptured property of the pokemons based on the local captured pokemons
        pokemonsSearchResponse.Items = pokemonsSearchResponse?.Items?.Select(p =>
        {
            p.IsCaptured = localCapturedPokemons.Items.Any(lp => lp.Id == p.Id);
            return p;
        }).ToList() ?? new();

        return pokemonsSearchResponse!;
    }

    public async Task<SearchResponse<PokemonDto>> GetMyPokemonsAsync(SearchRequest searchRequest)
    {
        var myPokemonsJson = await _localStorageService.GetItemAsync("myPokemons");
        var myPokemons = JsonSerializer.Deserialize<IEnumerable<PokemonDto>>(myPokemonsJson ?? "[]");

        if (!string.IsNullOrEmpty(searchRequest.SearchTerm))
        {
            myPokemons = myPokemons?
            .Where(p => p.Name.Contains(searchRequest.SearchTerm, StringComparison.OrdinalIgnoreCase));
        }
        var paginatedPokemons = myPokemons?
            .Skip((searchRequest.PageNumber - 1) * searchRequest.PageSize)
            .Take(searchRequest.PageSize).ToList();

        return new()
        {
            Items = paginatedPokemons ?? new List<PokemonDto>(),
            PageNumber = searchRequest.PageNumber,
            PageSize = searchRequest.PageSize,
            TotalItems = myPokemons?.Count() ?? 0,
            TotalPages = (int)Math.Ceiling((myPokemons?.Count() ?? 0) / (double)searchRequest.PageSize)
        };
    }

    public async Task<bool> IsCapturedAsync(int id)
    {
        var myPokemonsJson = await _localStorageService.GetItemAsync("myPokemons");
        var myPokemons = JsonSerializer.Deserialize<IEnumerable<PokemonDto>>(myPokemonsJson ?? "[]");
        return myPokemons?.Any(p => p.Id == id) ?? false;
    }

    public async Task CaptureAsync(PokemonDto pokemon)
    {
        var myPokemonsJson = await _localStorageService.GetItemAsync("myPokemons");
        var myPokemons = JsonSerializer.Deserialize<List<PokemonDto>>(myPokemonsJson ?? "[]") ?? new();
        pokemon.IsCaptured = true;
        myPokemons.Add(pokemon);
        await _localStorageService.SetItemAsync("myPokemons", JsonSerializer.Serialize(myPokemons));
    }

    public async Task ReleaseAsync(int id)
    {
        var myPokemonsJson = await _localStorageService.GetItemAsync("myPokemons");
        var myPokemons = JsonSerializer.Deserialize<List<PokemonDto>>(myPokemonsJson ?? "[]") ?? new();
        myPokemons.RemoveAll(p => p.Id == id);
        await _localStorageService.SetItemAsync("myPokemons", JsonSerializer.Serialize(myPokemons));
    }
}

