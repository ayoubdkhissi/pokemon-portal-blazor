using Microsoft.AspNetCore.Components;
using pokemon_portal_blazor.DTOs;

namespace pokemon_portal_blazor.Components;

public partial class PokemonCard : ComponentBase
{
    [Parameter]
    public PokemonDto Pokemon { get; set; } = new();
}
