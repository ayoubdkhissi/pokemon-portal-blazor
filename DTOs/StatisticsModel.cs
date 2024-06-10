namespace pokemon_portal_blazor.DTOs;
public class StatisticsModel
{
    public CatchCountCardData CatchCountCardData { get; set; }
    public List<AveragesByPowerData> AveragesByPower { get; set; }
    public List<CatchCountByPowerData> CatchCountByPower { get; set; }
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

public class CatchCountByPowerData
{
    public PowerDto Power { get; set; }
    public int Count { get; set; }
}