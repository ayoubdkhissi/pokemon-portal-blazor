using Microsoft.AspNetCore.Components;
using pokemon_portal_blazor.DTOs;
using pokemon_portal_blazor.Services;

namespace pokemon_portal_blazor.Pages;
public partial class Home : ComponentBase
{
    private ApiResponse<SearchResponse<PokemonDto>> ApiResponse = new();
    private SearchResponse<PokemonDto> PokemonSearchResponse = new();
    private SearchRequest SearchRequest = new();


    [Inject] IPokemonService PokemonService { get; set; }


    protected override async Task OnInitializedAsync()
    {
        SearchRequest = new SearchRequest { SearchTerm = string.Empty, PageNumber = 1, PageSize = 8 };
        await FetchData();

        await base.OnInitializedAsync();
    }

    private async Task OnPageChangedAsync(int pageNumber)
    {
        SearchRequest.PageNumber = pageNumber;
        await FetchData();
    }

    private async Task OnSearchAsync(string searchTerm)
    {
        SearchRequest.SearchTerm = searchTerm;
        SearchRequest.PageNumber = 1;
        await FetchData();
    }

    private async Task FetchData()
    {
        ApiResponse = await PokemonService.SearchAsync(SearchRequest);
        PokemonSearchResponse = ApiResponse.Data;
    }
}

