namespace pokemon_portal_blazor.DTOs;
public class StatisticsModel
{
    public CatchCountCardData CatchCountCardData { get; set; }
    public List<AveragesByPowerData> AveragesByPower { get; set; }
    public List<PokemonsByPowerData> PokemonsByPower { get; set; }
}

public class CatchCountCardData
{
    public List<string> Labels { get; set; } = [];
    public List<int> Counts { get; set; } = [];
}

public class AveragesByPowerData
{
    public PowerDto Power { get; set; }
    public int PokemonCount { get; set; }
    public double AvgAttack { get; set; }
    public double AvgDefense { get; set; }
}

public class PokemonsByPowerData
{
    public PowerDto Power { get; set; }
    public int CatchCount { get; set; }
    public int PokemonCount { get; set; }
}