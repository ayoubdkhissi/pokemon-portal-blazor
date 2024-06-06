using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using pokemon_portal_blazor.DTOs;

namespace pokemon_portal_blazor.Components.ChartCards;
public partial class CatchCountCard : ComponentBase
{
    [Parameter] public CatchCountCardData Data { get; set; } = new();

    private BarChart barChart = default!;
    private BarChartOptions barChartOptions = default!;
    private ChartData chartData = default!;

    protected override void OnInitialized()
    {
        var datasets = new List<IChartDataset>();

        var dataset1 = new BarChartDataset()
        {
            Data = Data.Counts.Select(d => (double)d).ToList(),
            BackgroundColor = new List<string> { ColorBuilder.CategoricalTwelveColors[0] },
            BorderColor = new List<string> { ColorBuilder.CategoricalTwelveColors[0] },
            BorderWidth = new List<double> { 0 },
        };
        datasets.Add(dataset1);

        chartData = new ChartData
        {
            Labels = Data.Labels,
            Datasets = datasets
        };

        barChartOptions = new BarChartOptions();
        barChartOptions.Responsive = true;
        barChartOptions.Interaction = new Interaction { Mode = InteractionMode.Y };
        barChartOptions.IndexAxis = "y";

        barChartOptions.Scales.X!.Title!.Text = "Catch Count";
        barChartOptions.Scales.X.Title.Display = true;

        barChartOptions.Scales.Y!.Title!.Text = "Pokemons";
        barChartOptions.Scales.Y.Title.Display = true;

        barChartOptions.Plugins.Legend.Display = false;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await barChart.InitializeAsync(chartData, barChartOptions);
        }
        await base.OnAfterRenderAsync(firstRender);
    }
}

