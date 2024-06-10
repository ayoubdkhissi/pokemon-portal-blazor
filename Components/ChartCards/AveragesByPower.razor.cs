using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using pokemon_portal_blazor.DTOs;

namespace pokemon_portal_blazor.Components.ChartCards;

public partial class AveragesByPower : ComponentBase
{
    private BarChart barChart = default!;
    private BarChartOptions barChartOptions = default!;
    private ChartData chartData = default!;
    

    [Parameter]
    public List<AveragesByPowerData> Data { get; set; } 

    protected override void OnInitialized()
    {
        chartData = new ChartData 
        { 
            Labels = Data.Select(p => p.Power.Name).ToList(), 
            Datasets = GetDataSets()
        };
        barChartOptions = new BarChartOptions { Responsive = true, Interaction = new Interaction { Mode = InteractionMode.Index } };
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await barChart.InitializeAsync(chartData, barChartOptions);
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    private List<IChartDataset> GetDataSets()
    {
        var datasets = new List<IChartDataset>
        {
            new BarChartDataset
            {
                Label = "Number of Pokemons",
                Data = Data.Select(d => (double)d.PokemonCount).ToList(),
                BackgroundColor = ["#543310"],
                BorderColor = ["#543310"],
                BorderWidth = [0]
            },
            new BarChartDataset
            {
                Label = "Average Attack",
                Data = Data.Select(d => d.AvgAttack).ToList(),
                BackgroundColor = ["#FF0000"],
                BorderColor = ["#FF0000"],
                BorderWidth = [0]
            },
            new BarChartDataset
            {
                Label = "Average Defense",
                Data = Data.Select(d => d.AvgDefense).ToList(),
                BackgroundColor = ["#A1DD70"],
                BorderColor = ["#A1DD70"],
                BorderWidth = [0]
            }
        };

        return datasets;
    }
}
