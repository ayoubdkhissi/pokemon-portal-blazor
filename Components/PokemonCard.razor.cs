using Microsoft.AspNetCore.Components;
using pokemon_portal_blazor.DTOs;

namespace pokemon_portal_blazor.Components;

public partial class PokemonCard : ComponentBase
{
    [Parameter]
    public PokemonDto Pokemon { get; set; } = new();

    [Parameter]
    public EventCallback<PokemonDto> OnPokemonCaptured { get; set; }

    [Parameter]
    public EventCallback<int> OnPokemonReleased { get; set; }

    private async Task CapturePokemonAsync()
    {
        await OnPokemonCaptured.InvokeAsync(Pokemon);
    }

    private async Task ReleasePokemonAsync()
    {
        await OnPokemonReleased.InvokeAsync(Pokemon.Id);
    }

}
