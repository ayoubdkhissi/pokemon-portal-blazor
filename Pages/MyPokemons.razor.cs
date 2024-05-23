using Microsoft.AspNetCore.Components;
using pokemon_portal_blazor.Components;
using pokemon_portal_blazor.DTOs;
using pokemon_portal_blazor.Services;

namespace pokemon_portal_blazor.Pages;
public partial class MyPokemons : ComponentBase
{
    [Inject] private IPokemonService PokemonService { get; set; }
    
    private SearchResponse<PokemonDto>? PokemonSearchResponse;
    private SearchRequest SearchRequest = new();
    private ConfirmationModal ConfirmationModal;

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
        PokemonSearchResponse = await PokemonService.GetMyPokemonsAsync(SearchRequest);
    }

    private async Task OnPokemonRelease(int id)
    {
        await PokemonService.ReleaseAsync(id);
        await FetchData();
    }


    private void ShowConfirmationModal()
    {
        ConfirmationModal.Show();
    }

    private async Task ReleaseAllPokemonsAsync(bool confirmed)
    {
        if (!confirmed)
        {
            return;
        }
        await PokemonService.ReleaseAllAsync();
        PokemonSearchResponse = new();
    }
}