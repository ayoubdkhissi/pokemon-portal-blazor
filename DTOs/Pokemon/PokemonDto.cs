﻿namespace pokemon_portal_blazor.DTOs;
public class PokemonDto : PokemonManipulationDto, IEntityDto
{
    public int Id { get; set; }
    public IEnumerable<PowerDto> Powers { get; set; } = [];
}