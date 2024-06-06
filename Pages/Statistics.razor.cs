using Microsoft.AspNetCore.Components;
using pokemon_portal_blazor.DTOs;
using pokemon_portal_blazor.Services;

namespace pokemon_portal_blazor.Pages;
public partial class Statistics : ComponentBase
{
    [Inject] IPokemonService PokemonService { get; set; }
    private StatisticsModel? StatisticsModel;


    protected override async Task OnInitializedAsync()
    {

        StatisticsModel = await PokemonService.GetStatisticsAsync();

    }

}