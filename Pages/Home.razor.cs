using Microsoft.AspNetCore.Components;
using pokemon_portal_blazor.DTOs;
using pokemon_portal_blazor.Services;

namespace pokemon_portal_blazor.Pages;
public partial class Home : ComponentBase
{
    private SearchResponse<PokemonDto> SearchResponse;


    [Inject] IPokemonService PokemonService { get; set; }


    protected override async Task OnInitializedAsync()
    {
        SearchResponse = new SearchResponse<PokemonDto>()
        {
            Items = new List<PokemonDto>(),
            PageNumber = 1,
            PageSize = 10,
            TotalPages = 6,
            TotalItems = 60
        };

        await base.OnInitializedAsync();
    }

    private void OnPageChanged(int pageNumber)
    {
        SearchResponse.PageNumber = pageNumber;
    }
}

