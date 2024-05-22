using Microsoft.AspNetCore.Components;
using pokemon_portal_blazor.DTOs;
using pokemon_portal_blazor.Services;

namespace pokemon_portal_blazor.Pages;
public partial class Home : ComponentBase
{
    private SearchResponse<PokemonDto> PokemonSearchResponse = new();
    private SearchRequest SearchRequest = new();


    [Inject] IPokemonService PokemonService { get; set; }


    protected override async Task OnInitializedAsync()
    {
        SearchRequest = new SearchRequest { SearchTerm = string.Empty, PageNumber = 1 };
        await FetchData();

        await base.OnInitializedAsync();
    }

    private async Task OnPageChangedAsync(int pageNumber)
    {
        SearchRequest = new()
        {
            PageNumber = pageNumber,
            PageSize = 8,
        };
        await FetchData();
    }

    private async Task OnSearchAsync(string searchTerm)
    {
        SearchRequest = new()
        {
            SearchTerm = searchTerm,
            PageNumber = 1
        };
        await FetchData();
    }

    private async Task FetchData()
    {
        PokemonSearchResponse = await PokemonService.SearchAsync(SearchRequest);
    }

    private async Task OnPokemonCapture(PokemonDto pokemon)
    {
        if (await PokemonService.IsCapturedAsync(pokemon.Id))
        {
            return;
        }
        PokemonSearchResponse = new()
        {
            Items = PokemonSearchResponse.Items.Select(p =>
            {
                if (p.Id == pokemon.Id)
                {
                    p.IsCaptured = true;
                }
                return p;
            }).ToList(),
            PageNumber = PokemonSearchResponse.PageNumber,
            PageSize = PokemonSearchResponse.PageSize,
            TotalItems = PokemonSearchResponse.TotalItems,
            TotalPages = PokemonSearchResponse.TotalPages
        };
        await PokemonService.CaptureAsync(pokemon);
    }

    private async Task OnPokemonRelease(int id)
    {
        PokemonSearchResponse = new()
        {
            Items = PokemonSearchResponse.Items.Select(p =>
            {
                if (p.Id == id)
                {
                    p.IsCaptured = false;
                }
                return p;
            }).ToList(),
            PageNumber = PokemonSearchResponse.PageNumber,
            PageSize = PokemonSearchResponse.PageSize,
            TotalItems = PokemonSearchResponse.TotalItems,
            TotalPages = PokemonSearchResponse.TotalPages
        };
        await PokemonService.ReleaseAsync(id);
    }
}

